using UnityEngine;

namespace Seizon {
public class WeaponController : MonoBehaviour
{
    //Put this on FPS controller

    private Camera FPScam;
    private Weapon weapon;       //Also current weapon
    
    //Particles
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    //Fire mode related
    private float nextAttackTime = 0;
    private bool onFireHold = false;

    //DEBUGS
    public GameObject debugTarget;        //Where the gun shot at
    // private LineRenderer debugRay;


    void Start()
    {
        //Set all core objects
        weapon = GetComponentInChildren<Weapon>();
        FPScam = GetComponentInChildren<Camera>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))   //Generally Left Mouse Click or Left Control
        {
            //Handle various fire modes
            switch (weapon.fireMode)
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
                        nextAttackTime = Time.time + 1f / weapon.fireRate;
                        Attack();
                    }
                    break;
            }
        }
        else
        {
            onFireHold = false;
        }
    }

    void Attack()
    {
        //Muzzle flash
        muzzleFlash.Play();

        //Reduce ammo count
        weapon.ammo--;

        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, weapon.range))
        {
            Debug.Log(hit.transform.name);

            Shootable target = hit.transform.GetComponent<Shootable>();
            //If valid shootable target is found
            if (target != null)
            {
                //Deal damage to it
                target.TakeDamage(weapon.damage);

                

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
            if (debugTarget != null) {
                debugTarget.transform.position = hit.point;
            }
        }


    }

}

}