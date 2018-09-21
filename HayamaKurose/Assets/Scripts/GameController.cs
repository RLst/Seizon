using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject m_pMenu;
    public GameObject m_tpMenu;
    public GameObject m_sMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (m_sMenu.activeSelf == false)
            {
                if (m_pMenu.activeSelf == true)
                {
                    m_pMenu.SetActive(false);
                }
                else
                {
                    m_pMenu.SetActive(true);
                }
            }
            else
            {
                m_tpMenu.SetActive(true);
                m_sMenu.SetActive(false);
            }
        }
	}
}
