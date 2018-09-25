using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Seizon
{
public class Overlay : MonoBehaviour
{
    public GameController GC;
    public GameObject FPSController;
    private Player player;
    public Text gameTime;
    public Text dayCount;
    public Text HP;
    public Text killCount;
    public Text remainingAmmo;      //Remaining ammo for current weapon
    public Text carriedAmmo;

    void Start()
    {
        player = FPSController.GetComponentInChildren<Player>();
    }

    void Update()
    {
        ////Update the HUD
        // gameTime.text = GameController.gameTimeSecs.ToString();
        
        //Format the game time
        var timeUnformatted = TimeSpan.FromSeconds(GC.gameTime);
        var timeFormatted = string.Format(
            "{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
            timeUnformatted.Hours,
            timeUnformatted.Minutes,
            timeUnformatted.Seconds,
            timeUnformatted.Milliseconds);

        dayCount.text = GC.dayCount.ToString();

        HP.text = player.health.ToString();

        killCount.text = GC.killCount.ToString();

        remainingAmmo.text = player.currentWeapon.remainingAmmo.ToString();

        carriedAmmo.text = player.ammoCarried[player.currentWeapon.type].ToString();

        Debug.Log("remaining ammo = " + player.currentWeapon.remainingAmmo.ToString());
    }
}
}