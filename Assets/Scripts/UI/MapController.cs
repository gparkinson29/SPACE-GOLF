using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapController : MonoBehaviour
{
    [SerializeField]public Sprite[] maps = new Sprite[3];

    public RawImage imageTargetProperty;

    public int currentLevel = 0; //0 - 2

    public GameObject screen;

    public void mapScreenToggle()
    {
        screen.SetActive(!screen.activeSelf);
    }

    // Update is called once per frame

    public void Update()
    {
        imageTargetProperty.texture = maps[currentLevel%2].texture;
    }
}
