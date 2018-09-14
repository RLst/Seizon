using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {


	//TEMP
	// public class Player
	// {
	// 	public GameObject obj

	// }


	public class PlayerAttack : MonoBehaviour {
		private GameObject player;	//SINGULAR
		public GameObject[] enemies;

		private Weapon weapon;

		private Ray shootRay;



		//Internal
		private float fireStartTime;
		private float fireDuration;

		// Use this for initialization
		void Start () {
			//Set players and enemies
			player = GameObject.FindGameObjectWithTag("Player");	//Temp?
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
		}
		
		// Update is called once per frame
		void Update () {
			
			
			////Handle weapon execution (universal; regardless of firerate, firemode.. all handled)
			if (Input.GetKey("Fire1"))
			{
				weapon.fire();
				
				shootRay = new Ray(transform.position, transform.forward);
				// var rayHit = 0;



                foreach (var enemy in enemies)
                {
					
                }

            }
			else //if input.getkeyup(fire1)
			{
				weapon.release();
			}


			// if (weapon) 
			// {
			// }
			// //Player "shoots" non-automatic weapon
			// if (Input.GetKeyDown("Fire1")) {
			// 	//MELEE
			// 	if (weapon.type == WeaponType.KNIFE) {

			// 	}
			// 	//HAND GUN
			// 	else if (weapon.type == WeaponType.HAND_GUN) {

			// 	}
			// 	else {
			// 		//ERROR?
			// 	}

			// }

			// //Player "shoots" automatic weapon
			// if (Input.GetKey("Fire1")) {
			// 	//ASSAULT RIFLE
			// 	if (weapon.type == WeaponType.ASSAULT_RIFLE) {
			// 	}
			// 	else  {
			// 		//ERROR?
			// 	}
			// }

		}
	}
}
