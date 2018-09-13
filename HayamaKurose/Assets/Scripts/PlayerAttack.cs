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
		private GameObject player;
		public GameObject[] enemies;

		private Weapon weapon;

		private Ray shootRay;

		// Use this for initialization
		void Start () {
			player = GameObject.FindGameObjectWithTag("Player");

		}
		
		// Update is called once per frame
		void Update () {
			
			if (weapon.isAutomatic) 
			{

			}

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
