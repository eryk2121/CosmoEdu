using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void Start()
    {
    }
    public void SwitchToStats()
    {
        SceneManager.LoadScene("Stats", LoadSceneMode.Single);
    }

    public void SwitchToShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }

    public void SwitchToShopPowerUps()
    {
        SceneManager.LoadScene("ShopPowerUps", LoadSceneMode.Single);

    }
    public void SwitchToQuestions()
    {
        SceneManager.LoadScene("Question", LoadSceneMode.Single);

    }
    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void SwitchToLaderboard()
    {
        SceneManager.LoadScene("Leader", LoadSceneMode.Single);

    }

    public void SwitchToOptions()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);

    }



    public void Exit()
    {
        Exit();
    }
}
