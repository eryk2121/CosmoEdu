using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    public Text maxScore;
    public Text maxCorrectAnswers;
    public Text gamesAmount;
    // Start is called before the first frame update
    void Start()
    {
        maxScore.text = "Max Score:" + PlayerPrefs.GetInt("MaxScore").ToString();
        maxCorrectAnswers.text = "Correct Answers:" + PlayerPrefs.GetInt("CorrectAnswer").ToString();
        gamesAmount.text = "Games Amount:" + PlayerPrefs.GetInt("GamesAmount").ToString();
    }
}
