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
        public GameObject daysSurvivedPanel;


        ////HUD Parameters
        [HideInInspector]
        public double gameTime = 0;
        [HideInInspector]
        public int dayCount = 0;
        [HideInInspector]
        public int killCount = 0;

        ////Spawn Parameters
        public int spawnsPerDay = 10;               //Initial settings
        public int additionalSpawnsPerDay = 15;     //Initial settings
        [HideInInspector]
        public int remainingSpawnsToday;       //Working
        public DayNightCycle sun;

        //Singleton pattern
        static GameController instance = null;


        void Start()
        {
            //Setup singleton gamecontroller
            if(instance != null)
            {
                //error
            }
            else
            {
                instance = this;
            }

            // GameController controller = GameObject.FindObjectOfType<GameController>();
            // if(controller.gameObject != gameObject)
            // {
            //     //Throw assert
            // }

            remainingSpawnsToday = spawnsPerDay;
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

            
            ///Check if all enemies of this day (wave) have been killed
            if (remainingSpawnsToday == 0 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                //If so then fast forward the day
                sun.FastForward();
                //The sun will automatically trigger StartNewDay() at the next morning

            }
        }


        public void StartNewDay()
        {
            //Next day!!! Let the user know (GUI panel)
            // dayCount++;
            ShowNextDayGUIPanel();

            //Add on new number of spawns for the next day
            remainingSpawnsToday += spawnsPerDay + (additionalSpawnsPerDay * dayCount);
            Debug.Log("EndDay(); remainingSpawnsToday = " + remainingSpawnsToday);
        }

        public void ShowNextDayGUIPanel()
        {
            Debug.Log("You've survived day " + dayCount);
            //Implement GUI Panel
        }

    }
}


////Game sequences
/*
1. Day Zero, No enemies yet, Player in the center somewhere
2. Spawners start spawning, decrementing GC.remainingSpawnsToday
3. If player kills all enemies ie. GC.remainingSpawnsToday = 0, start new day:
    - Increment GC.daycount
    - ShowNextDayGUIPanel()
    - Update remainingSpawnsToday
    - 


 */