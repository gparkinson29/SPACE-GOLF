using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInstance : MonoBehaviour
{
    [SerializeField]
    private MissionData missionDataSO;
    [SerializeField]
    private Image missionIcon, greyedOut, lockIcon;
    [SerializeField]
    private Text missionName;
    [SerializeField]
    private List<LevelInstance> associatedLevels;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Button levelAccess;

    private void Awake()
    {
        missionIcon.sprite = missionDataSO.GetSprite();
        missionName.text = missionDataSO.GetAreaName();
    }
    
    public void OnMissionClick()
    {
        foreach(LevelInstance level in associatedLevels)
        {
            level.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public List<LevelInstance> GetAssociatedLevels()
    {
        return associatedLevels;
    }

    public Animator GetAnimator()
    {
        return anim;
    }

    public Image GetGreyOut()
    {
        return greyedOut;
    }

    public Image GetLockIcon()
    {
        return lockIcon;
    }

    public Button GetLevelAccessButton()
    {
        return levelAccess;
    }
}
