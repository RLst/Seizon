using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Camera fpsCam;
    public Weapon weapon;       //Also current weapon

    private float timeToNextAttack = 0;
    private bool onFireHold = false;

    //Particles
    public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;


    //DEBUGS
    public GameObject gunEnd;
    // private LineRenderer debugRay;

    void Update()
    {

        //if (Input.GetButton("Fire1") && Time.time >= timeToNextAttack)
        if (Input.GetButton("Fire1"))
        {
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
                    if (!onFireHold)
                    {
                        onFireHold = true;
                        Attack();
                    }
                    break;

                case FireMode.AUTOMATIC:
                    if (Time.time >= timeToNextAttack)
                    {
                        timeToNextAttack = Time.time + 1f / weapon.fireRate;
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
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weapon.range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            //If valid shootable target is found
            if (target != null)
            {
                // debugRay.SetPosition(1, hit.point);

                //Deal damage to it
                target.TakeDamage(weapon.damage);
            }
            else
            {
                //Limit length of debug ray
                // debugRay.SetPosition(1, fpsCam.transform.forward * 100f);
            }

            //Position bullet impact point
            gunEnd.transform.position = hit.point;

            //Control impact particle effect
            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            // Destroy(impactEffect, 1.5f);

        }


    }

}
