using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseScreen;
    public GameObject indicator = null;
    public EnemyButtonManager EnemyButtonManager;
    public void PauseGame()
    {
        GetIndicator();
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            if (EnemyButtonManager.isPressedOne)
            {
                EnemyButtonManager.indicatorOne.SetActive(false);
            }
            else if (EnemyButtonManager.isPressedTwo)
            {
                EnemyButtonManager.indicatorTwo.SetActive(false);
            }
            else if (EnemyButtonManager.isPressedThree)
            {
                EnemyButtonManager.indicatorThree.SetActive(false);
            }
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (isPaused)
        {
            pauseScreen.SetActive(false);
            if (EnemyButtonManager.isPressedOne)
            {
                EnemyButtonManager.indicatorOne.SetActive(true);
            }
            else if (EnemyButtonManager.isPressedTwo)
            {
                EnemyButtonManager.indicatorTwo.SetActive(true);
            }
            else if (EnemyButtonManager.isPressedThree)
            {
                EnemyButtonManager.indicatorThree.SetActive(true);
            }
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    void GetIndicator()
    {
        if (EnemyButtonManager.isPressedOne)
        {
            indicator = EnemyButtonManager.indicatorOne;
        }
        else if (EnemyButtonManager.isPressedTwo)
        {
            indicator = EnemyButtonManager.indicatorTwo;
        }
        else if (EnemyButtonManager.isPressedThree)
        {
            indicator = EnemyButtonManager.indicatorThree;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Roman_Scene");
        Time.timeScale = 1f;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quits game.");
        Application.Quit();
    }
}
