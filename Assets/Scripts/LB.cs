using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LB : MonoBehaviour
{
    public Text lb1;
    public Text lb2;
    public Text lb3;
    public Text lb4;
    public Text lb5;

    void Start()
    {
        LoadAndSetBoard();
    }

    public void LoadAndSetBoard()
    {
        lb1.text = "1. " + PlayerPrefs.GetInt("1");
        lb2.text = "2. " + PlayerPrefs.GetInt("2");
        lb3.text = "3. " + PlayerPrefs.GetInt("3");
        lb4.text = "4. " + PlayerPrefs.GetInt("4");
        lb5.text = "5. " + PlayerPrefs.GetInt("5");
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
