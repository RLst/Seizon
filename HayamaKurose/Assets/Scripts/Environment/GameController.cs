using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon
{
    public class GameController : MonoBehaviour
    {
        ///Add this script to a empty object

        ////Menus
        public GameObject pauseMenu;
        public GameObject topPauseMenu;
        public GameObject settingsMenu;


        ////HUD Parameters
        public double gameTime;
        public int dayCount;
        // public static float HP;     //This should be in Player.cs
        //Number of kills the player has made
        public int killCount;
        //Ammo carried by the player for each type of weapon
        // public Dictionary<WeaponType, int> CarriedAmmo { get; set; }  


        ////Spawn Parameters
        public int spawnsPerDay = 20;               //Initial settings
        public int additionalSpawnsPerDay = 10;     //Initial settings
        private int remainingSpawnsToday = 20;       //Working
        public DayNightCycle sunNmoon;


        void Start()
        {
            gameTime = 0;
            dayCount = 0;

            // //Set Carried Ammo defaults
            // CarriedAmmo.Add(WeaponType.KNIFE, -1);          //Knife has unlimited "ammo"
            // CarriedAmmo.Add(WeaponType.KATANA, -1);         //Katana has unlimited "ammo"
            // CarriedAmmo.Add(WeaponType.HAND_GUN, 36);       //3 clips of handgun ammo to start off with
            // CarriedAmmo.Add(WeaponType.ASSAULT_RIFLE, 0);
            // CarriedAmmo.Add(WeaponType.ROCKET_LAUNCHER, 0);
        }

        // Update is called once per frame
        void Update()
        {

            ///Handle menu controls?
            if (Input.GetKeyDown("escape"))
            {
                if (settingsMenu.activeSelf == false)
                {
                    if (pauseMenu.activeSelf == true)
                    {
                        pauseMenu.SetActive(false);
                    }
                    else
                    {
                        pauseMenu.SetActive(true);
                    }
                }
                else
                {
                    topPauseMenu.SetActive(true);
                    settingsMenu.SetActive(false);
                }
            }
            
            ///Update game time since started playing
            gameTime += Time.deltaTime;    

            
            ///Check all enemies killed
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) {
                sunNmoon.FastForward();
            }
                
        }


        public void StartNewDay()
        {
            //Next day!!! Let the user know (GUI panel)
            dayCount++;
            ShowNextDayGUIPanel();

            //Add on new number of spawns for the next day
            remainingSpawnsToday += spawnsPerDay + additionalSpawnsPerDay * dayCount;
            Debug.Log("EndDay(); remainingSpawnsToday = " + remainingSpawnsToday);

            //If all spawn subjects are dead then speed the day up until morning
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) {
                sunNmoon.FastForward();
            }
        }

        public void ShowNextDayGUIPanel()
        {
            Debug.Log("You've survived Day " + dayCount);
            //Implement GUI Panel
        }

    }
}