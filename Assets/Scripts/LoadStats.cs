using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    public Data dataBase;
    public Text maxScore;
    public Text maxCorrectAnswers;
    public Text gamesAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        gamesAmount.text = "Liczba gier: " + dataBase.AmountOfPlay.ToString();
        maxCorrectAnswers.text = "Poprawne odpowiedzi:" + dataBase.CorrectAnserwrs.ToString();
        maxScore.text = "Najwyższy wynik:" + dataBase.HighScore.ToString();
    }
}
