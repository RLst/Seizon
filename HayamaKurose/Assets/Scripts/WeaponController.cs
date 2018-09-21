using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon
{
    
    public class WeaponController : MonoBehaviour
    {

        public Camera fpsCam;
        public Weapon weapon;       //Also current weapon
        //damage = weapon.damage
        //range = weapon.range
        //fireRate = weapon.fireRate
        //impactForce = weapon.impactForce

        private float timeToNextAttack = 0;
        private bool onFireHold = false;

        //Particles
        public ParticleSystem muzzleFlash;
        public GameObject impactEffect;



        //DEBUGS
        private LineRenderer debugRay;

        void Update()
        {
            
            //if (Input.GetButton("Fire1") && Time.time >= timeToNextAttack)
            if (Input.GetButton("Fire1"))
            {
                switch (weapon.fireMode)
                {
                    case FireMode.SINGLE:
                        //MIGHT NOT NEED TO IMPLEMENT THIS AS THERE MAY NOT BE ANY SINGLE SHOT WEAPONS
                        onFireHold = true;
                        Attack();
                        break;

                    case FireMode.SEMI_AUTOMATIC:
                        onFireHold = true;
                        Attack();
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
            RaycastHit hitInfo;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, weapon.range)) 
            {
                Debug.Log(hitInfo.transform.name);

                Target target = hitInfo.transform.GetComponent<Target>();
                //If valid shootable target is found
                if (target != null)
                {
                    debugRay.SetPosition(1, hitInfo.point);

                    //Deal damage to it
                    target.TakeDamage(weapon.damage);
                }
                else
                {
                    //Limit length of debug ray
                    debugRay.SetPosition(1, fpsCam.transform.forward * 100f);
                }

                //Control impact particle effect
                Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impactEffect, 1.5f);

            }


        }

    }

}