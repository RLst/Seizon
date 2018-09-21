using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Seizon
{
    public class MainMenu : MonoBehaviour
    {
        //Get Panels for Switching
        public GameObject m_MainMenuPanel;
        public GameObject m_SettingPanel;

        private void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Load Scene "MainScene" when button is pressed
        public void PlayGameButtonOnClick()
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Switch Panel to Settings Panel
        public void SettingsButtonOnClick()
        {
            m_MainMenuPanel.SetActive(false);
            m_SettingPanel.SetActive(true);
        }
        
        //Quit Game when button is pressed
        public void QuitGameOnClick()
        {
            Application.Quit();
        }
    }
}
