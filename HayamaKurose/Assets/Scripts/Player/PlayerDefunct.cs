using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {

public class PlayerDEFUNCT : MonoBehaviour {

	//Handles core Player stuff....
	public Weapon currentWeapon;
	public int Health { get; set; }

	///Player actually holds all weapons
	//Weapons gets enabled if picked up, disabled if dropped
	private List<Weapon> CarriedWeapons {get; set; }

	// private static List<WeaponType> CarriedAmmo { get; set; }
	public Dictionary<WeaponType, int> CarriedAmmo { get; set; } 

	void Start()
	{
		//Set Carried Ammo defaults
		CarriedAmmo.Add(WeaponType.KNIFE, -1);          //Knife has unlimited "ammo"
		CarriedAmmo.Add(WeaponType.KATANA, -1);         //Katana has unlimited "ammo"
		CarriedAmmo.Add(WeaponType.HAND_GUN, 36);       //3 clips of handgun ammo to start off with
		CarriedAmmo.Add(WeaponType.ASSAULT_RIFLE, 0);
		CarriedAmmo.Add(WeaponType.ROCKET_LAUNCHER, 0);
	}

	void Update() {
		

	}

	void PickupWeapon(Weapon weaponPickedUp)
	{
		CarriedWeapons.Add(weaponPickedUp);		//Add the new weapon
		SwitchWeapon(CarriedWeapons[CarriedWeapons.Count - 1]);		//... and switch to the new weapon
	}

	void SwitchWeapon(Weapon weapon)
	{
		currentWeapon = weapon;
	}

	void DropWeapon()	//Drops the current weapon
	{
		CarriedWeapons.Remove(currentWeapon);
	}

}

}