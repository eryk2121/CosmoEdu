using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class Question : MonoBehaviour
{
    public Text question;
    public Text ansA;
    public Text ansB;
    public Text ansC;
    public Text correct;
    public Text funfact;


    public void AddQuestion()
    {
        var text = Resources.Load<TextAsset>("QuizData");
        string newS = text.ToString().Remove(text.ToString().Length - 1) + "*" + question.text + ":" + ansA.text + ":" + ansB.text + ":" + ansC.text + ":" + correct.text + ":" + funfact.text;
        File.WriteAllText(Application.dataPath + "/Resources/QuizData" + ".txt", newS);
      
    }
}
