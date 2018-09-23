using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Seizon
{
    public class Overlay : MonoBehaviour
    {

        public Text m_HP;
        public Text m_Timer;
        public Text m_KillCount;
        public Text m_Round;
        public Text m_ClipRemaining;
        public Text m_TotalAmmo;
        GameController m_GC;

        // Use this for initialization
        void Start()
        {
            // m_Timer.text = m_GC.m_fRoundTime.ToString() + " / " + m_GC.m_fGameTime.ToString(); 
        }

        // Update is called once per frame
        void Update()
        {
            //m_Timer.text = m_GC.m_fRoundTime.ToString() + " / " + m_GC.m_fGameTime.ToString();
        }
    }
}