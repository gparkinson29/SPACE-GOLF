using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIfeebackController : MonoBehaviour
{
    public TMP_Text m_Text;
    PlayerController m_Controller;

    private void Awake()
    {
        m_Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        m_Text.text = "("+m_Controller.debugCon.GetGameState() +")\n"+m_Controller.powerOutput.magnitude;
    }
}
