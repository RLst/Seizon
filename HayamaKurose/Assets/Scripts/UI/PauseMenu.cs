using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject m_FPSCon;
    public GameObject m_pMenu;
    public GameObject m_sPanel;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update () {
	}

    private void OnEnable()
    {
        m_FPSCon.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        m_FPSCon.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnResumeButtonDown()
    {
        this.gameObject.SetActive(false);
    }
    
    public void OnSettingsButtonDown()
    {
        m_sPanel.SetActive(true);
        m_pMenu.SetActive(false);
    }

    public void OnMainMenuButtonDown()
    {
        SceneManager.LoadScene("Menu");
    }

}
