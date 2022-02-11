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

}
