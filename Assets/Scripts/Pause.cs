using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pause = true;
    public GameObject pausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause = false;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause = true;
        pausePanel.SetActive(false);
    }
}
