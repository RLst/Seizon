using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {
public class Player : MonoBehaviour
{
    ///Attach this script to the root FPS controller

    ////Core
    public Weapon currentWeapon;
    public int health = 100;
    private GameController GC;
    private Camera fpsCam;
    // private PlayerDEFUNCT player;
    
    ////Weapons and Ammo

    //List of weapons the player is carrying
    [HideInInspector]
    public List<Weapon> weaponsCarried = new List<Weapon>();

    //List of ammo for each weapon carried
    [HideInInspector]
    public Dictionary<WeaponType, int> ammoCarried;

    ////Fire mode related
    private float nextAttackTime = 0;
    private bool onFireHold = false;
    private bool isReloading;
    
    ////Particles
    public GameObject impactEffect;
    private ParticleSystem muzzleFlash;

    ///DEBUGS
    public GameObject debugTarget;        //Where the gun shot at
    // private LineRenderer debugRay;


    void Start()
    {
        //Find the one and only gamecontroller
        GC = GameObject.FindObjectOfType<GameController>();

        //Set all core objects
        fpsCam = GetComponentInChildren<Camera>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();

        ///Setup the player's weapons
        weaponsCarried = new List<Weapon>();
        weaponsCarried.Add(GetComponentInChildren<Weapon>());   //Adds a handgun
        currentWeapon = weaponsCarried[weaponsCarried.Count-1];

        ///Set each ammo for each weapon carried by the player
        ammoCarried = new Dictionary<WeaponType, int>();
		ammoCarried.Add(WeaponType.KNIFE, -1);          //Knife has unlimited "ammo"
		ammoCarried.Add(WeaponType.KATANA, -1);         //Katana has unlimited "ammo"
		ammoCarried.Add(WeaponType.HAND_GUN, 36);       //3 clips of handgun ammo to start off with
		ammoCarried.Add(WeaponType.ASSAULT_RIFLE, 0);
		ammoCarried.Add(WeaponType.ROCKET_LAUNCHER, 0);
    }

    void Update()
    {
        ////Attack with current weapon
        if (Input.GetButton("Fire"))   //Generally Left Mouse Click or Left Control
        {
            //Handle various fire modes
            switch (currentWeapon.fireMode)
            {
                case FireMode.SINGLE:
                    //MIGHT NOT NEED TO IMPLEMENT THIS AS THERE MAY NOT BE ANY SINGLE SHOT WEAPONS
                    if (!onFireHold)
                    {
                        onFireHold = true;
                        Attack();
                    }
                    break;

                case FireMode.SEMI_AUTOMATIC:
                    //Fire ONE shot per button press and release
                    if (!onFireHold)
                    {
                        onFireHold = true;
                        Attack();
                    }
                    break;

                case FireMode.AUTOMATIC:
                    //Hold down button for multiple shots
                    if (Time.time >= nextAttackTime)
                    {
                        nextAttackTime = Time.time + 1f / currentWeapon.fireRate;
                        Attack();
                    }
                    break;
            }
        }
        else
        {
            onFireHold = false;
        }


        ////Reload
        // if (Input.GetButtonDown("Reload"))
        if (Input.GetKeyDown(KeyCode.R))
        {
            //If there's any bullets left on the player
            if (ammoCarried[currentWeapon.type] > 0) {

                //Play reloading animation

                //Disable shooting until animation finished or player switches weapon
                isReloading = true;

                //Once reload animation has finished and was not interrupted THEN finally reload the weapon
                Reload();
            }
        }


        ////Switch Weapons

    }

    void Attack()
    {
        //If enough bullets in clip
        if (currentWeapon.remainingAmmo != 0)
        {
            //Muzzle flash
            muzzleFlash.Play();

            //Reduce ammo count
            currentWeapon.remainingAmmo--;

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, currentWeapon.range))
            {
                // Debug.Log(hit.transform.name);
                Shootable target = hit.transform.GetComponent<Shootable>();
                //If valid shootable target is found
                if (target != null)
                {
                    //Deal damage to it
                    target.TakeDamage(currentWeapon.damage);
                    // debugRay.SetPosition(1, hit.point);
                }
                else
                {
                    //Limit length of debug ray
                    // debugRay.SetPosition(1, fpsCam.transform.forward * 100f);
                }

                //Control impact particle effect
                var GO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 1.5f);

                //DEBUG Position target
                if (debugTarget != null)
                {
                    debugTarget.transform.position = hit.point;
                }
            }
        }
        else {  //Not enough bullets MILORD!
            //Play empty gun click sound()
        }
    }

    void Reload()
    {
        // Debug.Log("Reloading...");
        ///Is the weapon reloadable? ie. not a melee weapon
        if (currentWeapon.type != WeaponType.KNIFE || 
            currentWeapon.type != WeaponType.KATANA) {
            
            //Reload; Subtract from carried ammo
            if (ammoCarried[currentWeapon.type] >= currentWeapon.magazineSize)
            {
                currentWeapon.remainingAmmo = currentWeapon.magazineSize;
                ammoCarried[currentWeapon.type] -= currentWeapon.magazineSize;
            }
            else {
                currentWeapon.remainingAmmo += ammoCarried[currentWeapon.type];
                ammoCarried[currentWeapon.type] = 0;
            }
        }

        //Reloading complete
        isReloading = false;
    }

    void PrevWeapon()
    {
        //Switch to the previous body
    }

    void NextWeapon()
    {
        //Switch to the next weapon
    }

    void LastUsedWeapon()
    {
        //Switches to last used weapon

        // player.CurrentWeapon = 

    }

    void PickupWeapon(Weapon weaponPickedUp)
	{
		weaponsCarried.Add(weaponPickedUp);		//Add the new weapon
		SwitchWeapon(weaponsCarried[weaponsCarried.Count - 1]);		//... and switch to the new weapon
	}

	void SwitchWeapon(Weapon weapon)
	{
		currentWeapon = weapon;
	}

	void DropWeapon()	//Drops the current weapon
	{
		weaponsCarried.Remove(currentWeapon);
	}

}

}