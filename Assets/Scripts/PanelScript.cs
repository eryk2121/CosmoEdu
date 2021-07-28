using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PanelScript : MonoBehaviour
{
    public Ship ship;

   

    public void Start()
    {
       
    }

    public void Restart()
    {
        ship.Restart();
    }

    public void SwitchToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void SwitchToGame() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void SwitchToLaderboard() {
        SceneManager.LoadScene("Leader", LoadSceneMode.Single);

    }
    public void Exit() {
        Exit();
    }

    /*public void PrepareLeaderBoard()
    {
        if (!PlayerPrefs.HasKey("1"))
        {
            PlayerPrefs.SetInt("1", 0);
        }
        if (!PlayerPrefs.HasKey("2"))
        {
            PlayerPrefs.SetInt("2", 0);
        }
        if (!PlayerPrefs.HasKey("3"))
        {
            PlayerPrefs.SetInt("3", 0);
        }
        if (!PlayerPrefs.HasKey("4"))
        {
            PlayerPrefs.SetInt("4", 0);
        }
        if (!PlayerPrefs.HasKey("5"))
        {
            PlayerPrefs.SetInt("5", 0);
        }
    }*/

   
}
