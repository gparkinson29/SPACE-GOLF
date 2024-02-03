using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionScreen : MonoBehaviour
{
    public void OnTutorialClicked()
    {
        SceneManager.LoadScene(3);
    }

    public void On1_1Clicked()
    {
        SceneManager.LoadScene(4);
    }

    public void On1_2Clicked()
    {
        SceneManager.LoadScene(4);
    }
}
