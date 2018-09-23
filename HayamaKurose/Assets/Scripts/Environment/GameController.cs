using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon
{
    public class GameController : MonoBehaviour
    {
        public GameObject m_pMenu;
        public GameObject m_tpMenu;
        public GameObject m_sMenu;
        public float m_fGameTime;
        public float m_fRoundTime;
        // Use this for initialization
        void Start()
        {
            m_fGameTime = 0;
            m_fRoundTime = 0;
        }

        // Update is called once per frame
        void Update()
        {
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
                m_fGameTime += Time.deltaTime;
                m_fRoundTime += Time.deltaTime;
        }
    }
}