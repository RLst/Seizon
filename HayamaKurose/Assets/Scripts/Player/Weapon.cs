using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Seizon {

public enum WeaponType
{
    KNIFE = 0,
    KATANA,
    HAND_GUN,
    ASSAULT_RIFLE,
    ROCKET_LAUNCHER
}

public enum FireMode
{
    SINGLE,
    SEMI_AUTOMATIC,
    AUTOMATIC
}

public class Weapon : MonoBehaviour
{

    public float range = 1;     //in Metres; Range of the weapon
    public float damage = 5;    //in Hitpoints; Max damage that will be dealt by the weapon
    public float fireRate = 100;    //Rounds PM
    public FireMode fireMode;
    public WeaponType type;

    //Core
    public int remainingAmmo = 12;   //-1 means unlimited
    public int magazineSize = 12;


    // public Weapon PreviousWeapon(Weapon currentWeapon) {
    //     if (currentWeapon <= 0) {
    //         return currentWeapon.weasdfasdf
    //     }
    // }

}

}