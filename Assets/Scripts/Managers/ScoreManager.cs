using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore()
    {
        score++;
    }
}
