using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Seizon {
    public class GameOver : MonoBehaviour {
        public Text DaysSurvived;
        public Text HayamasKilled;
        private GameController GC;
        // Use this for initialization
        void Start() {
            GC = FindObjectOfType<GameController>();
            DaysSurvived.text = "You survived " + GC.dayCount + " day(s)";
            HayamasKilled.text = "You killed " + GC.killCount + " Hayama(s)";
        }

        // Update is called once per frame
        void Update() {

        }

        public void TryAgainButtonOnPress()
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void MainMenuButtonOnPress()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
