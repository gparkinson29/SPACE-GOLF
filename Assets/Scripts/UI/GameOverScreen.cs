using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMissionsButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
