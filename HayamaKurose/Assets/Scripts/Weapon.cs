using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {

	public enum WeaponType {
		KNIFE,
		KATANA,
		HAND_GUN,
		ASSAULT_RIFLE,
		ROCKET_LAUNCHER
	}

	public class Weapon : MonoBehaviour {

		public float range = 1;		//in Metres; Range of the weapon
		public float damage = 5;	//in Hitpoints; Max damage that will be dealt by the weapon
		public bool isAutomatic = false;
		public WeaponType type;
	}

}