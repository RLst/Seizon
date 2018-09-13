using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {

	public enum WeaponType {
		MELEE,
		HAND_GUN,
		ASSAULT_RIFLE
	}

	public class Weapon : MonoBehaviour {

		public float range;		//in Metres; Range of the weapon
		public float damage;	//in Hitpoints; Max damage that will be dealt by the weapon
		public WeaponType type;
	}

}