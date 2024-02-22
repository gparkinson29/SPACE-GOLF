using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionScreen : MonoBehaviour
{
    [SerializeField]
    private MissionInstance[] levelList;
    private List<LevelInstance> linkedLevels;
    private int playerLevel;
    [SerializeField]
    private Dialogue missionTutorialDialogue;

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

        if (playerLevel==0)
        {
            levelList[1].GetLockIcon().gameObject.SetActive(true);
            levelList[1].GetGreyOut().gameObject.SetActive(true);
            levelList[1].GetLevelAccessButton().interactable = false;
            levelList[1].GetAnimator().SetBool("isUnlocked", false);
            levelList[0].GetAnimator().SetBool("isUnlocked", true);
            EventManager.Instance.PUTTDialogueSubscriber(missionTutorialDialogue);
            EventManager.Instance.DialogueUIOpen();
        }

        for (int i = 0; i < levelList.Length; i++)
        {
            linkedLevels = levelList[i].GetAssociatedLevels();
            for (int j = 0; j < levelList[i].GetAssociatedLevels().Count; j++)
            {

                if (linkedLevels[j].GetLevelNumber() > playerLevel)
                {
                    //enable the lock icon and set the color to something other than white
                    
                    linkedLevels[j].GetLockIcon().gameObject.SetActive(true);
                    linkedLevels[j].GetGreyOut().gameObject.SetActive(true);
                    linkedLevels[j].GetLevelAccessButton().interactable = false;
                    
                }
            }
        }
        //if 0, start putt

    }

    public void OnTutorialClicked()
    {
        SceneManager.LoadScene(3);
    }

    public void OnKitchenClicked()
    {
        SceneManager.LoadScene(4);
    }

    public void OnHangarClicked()
    {
        SceneManager.LoadScene(5);
    }

    public void OnEngineClicked()
    {
        SceneManager.LoadScene(6);
    }

    public void OnOutsideClicked()
    {
        SceneManager.LoadScene(7);
    }
}
