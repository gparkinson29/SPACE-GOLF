using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "missionData", menuName = "missionData")]
public class MissionData : ScriptableObject
{
    [SerializeField]
    private string areaName;
    [SerializeField]
    private Sprite areaIcon;
    [SerializeField]
    private int minimumLevelToAccess;

    public string GetAreaName() { return areaName; }
    public Sprite GetSprite() { return areaIcon; }
    public int GetMinimumLevelToAccess() {  return minimumLevelToAccess; }
}
