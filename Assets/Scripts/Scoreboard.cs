using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public Data dataBase;
    public List<Text> texts;

    void Start()
    {
        LoadAndSetBoard();
    }

    public void LoadAndSetBoard()
    {
        List<int> scores = new List<int>(dataBase.BestScores);
        scores.Reverse();

        for (int i =0; i<scores.Count; i++)
        {
            if(scores[i] != 0)
            {
                texts[i].text = (i+1).ToString()+ ". "+ scores[i].ToString();
            }
            else
            {
                texts[i].text = "Brak danych";
            }
        }
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
