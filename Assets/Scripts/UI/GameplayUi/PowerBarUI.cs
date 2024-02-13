using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarUI : MonoBehaviour
{
    //Controls the power bar section of the gameplay UI
    [SerializeField] public List<RawImage> powerBars;
    private int power = 10;
    // Update is called once per frame
    void Update()
    {
        updatePower();
    }

    public void updatePower()
    {
        int powerNum = 0;
        if (power != 0)
        {
            powerNum = (power % 10);
        }
        else
        {
            powerNum = 0;
        }
        for (int i = 0; i < powerBars.Count; i++)
        {
            if (i < powerNum || (power > 0 && powerNum == 0))
            {
                powerBars.ElementAt(i).gameObject.SetActive(true);
            }
            else
            {
                powerBars.ElementAt(i).gameObject.SetActive(false);
            }
        }
    }

    public void SetPower(int n)
    {
        power = n;
    }

    public void updateBars(Texture2D up, Texture2D down)
    {
        for (int i = 0; i < powerBars.Count; i++)
        {
            if (i%2 == 0)//Even ones are up (starting at index 0)
            {
                powerBars.ElementAt(i).texture = up;
            }
            else//odd ones are down
            {
                powerBars.ElementAt(i).texture = down;
            }
        }
    }
}
