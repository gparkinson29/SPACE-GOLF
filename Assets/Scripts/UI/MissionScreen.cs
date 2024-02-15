using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionScreen : MonoBehaviour
{
    [SerializeField]
    private LevelInstance[] levelList;
    private int playerLevel;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("currentLevel") == null)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
        else
        {
            playerLevel = PlayerPrefs.GetInt("currentLevel");
        }
        for (int i = 0; i < levelList.Length; i++)
        {
            if (levelList[i].GetLevelNumber() > playerLevel)
            {
                //enable the lock icon and set the color to something other than white
                levelList[i].GetLockIcon().gameObject.SetActive(true);
                levelList[i].GetGreyOut().gameObject.SetActive(true);
                levelList[i].GetLevelAccessButton().interactable = false;
                levelList[i].GetAnimator().SetBool("isUnlocked", false);
            }
            else
            {
                levelList[i].GetAnimator().SetBool("isUnlocked", true);
            }
        }

    }

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
