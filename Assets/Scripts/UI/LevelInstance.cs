using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelInstance : MonoBehaviour
{
    [SerializeField]
    private LevelData instanceData;
    //need references to the template's icon and text fields so we can set them with the assigned
    //SO's attributes in Awake()
    [SerializeField]
    private Image imgPlaceholder, greyedOut, lockIcon;
    [SerializeField]
    private Text textPlaceholder;
    [SerializeField]
    private Button levelAccess;


    private void Awake()
    {
        //otherwise, we don't need to alter the defaults when the scene loads
        imgPlaceholder.sprite = Resources.Load<Sprite>("UI/LevelIcons/" + instanceData.GetIcon());
        textPlaceholder.text = instanceData.GetLevelName();
    }

    public int GetLevelNumber()
    {
        return instanceData.GetLevelNum();
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
