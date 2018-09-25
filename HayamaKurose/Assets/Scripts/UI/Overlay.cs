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
    // public GameObject FPSController;
    private Player player;
    public Text gameTime;
    public Text dayCount;
    public Text HP;
    public Text killCount;
    public Text remainingAmmo;      //Remaining ammo for current weapon
    public Text ammoCarried;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        //Format the game time
        var timeUnformatted = TimeSpan.FromSeconds(GC.gameTime);
        var timeFormatted = string.Format(
            "{0:D2}:{1:D2}:{2:D3}",
            timeUnformatted.Minutes,
            timeUnformatted.Seconds,
            timeUnformatted.Milliseconds);
        gameTime.text = timeFormatted;

        dayCount.text = GC.dayCount.ToString();

        HP.text = player.health.ToString();

        killCount.text = GC.killCount.ToString();

        remainingAmmo.text = player.currentWeapon.remainingAmmo.ToString();

        ammoCarried.text = player.ammoCarried[player.currentWeapon.type].ToString();

    }
}

}