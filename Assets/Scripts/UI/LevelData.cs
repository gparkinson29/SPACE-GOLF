using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelData", menuName = "levelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int levelNumber;
    [SerializeField]
    private Sprite levelIcon;
    [SerializeField]
    private string levelName;

    public string GetLevelName()
    {
        return levelName;
    }

    public string GetIcon()
    {
        return levelIcon.name;
    }

    public int GetLevelNum()
    {
        return levelNumber;
    }
}
