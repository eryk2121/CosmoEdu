using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionShowButton : MonoBehaviour
{
    public GameObject panel;
    public Data database;
    public TextMeshProUGUI panelQuestions;
    public Text textButton;
    public bool isActivate;

    public void OnClickQuestionShowButton()
    {
        if(isActivate == false)
        {
            ShowQuestions();
        }
        else
        {
            HideQuestions();
        }
    }

    private void ShowQuestions()
    {
        panel.SetActive(true);
        textButton.text = "Schowaj pytania";
        FillData();
        isActivate = true;
    }

    private void HideQuestions()
    {
        panel.SetActive(false);
        textButton.text = "Poka¿ pytania";
        isActivate = false;
    }

    private void FillData()
    {
        string listOfQuestion = string.Empty;

        if (database.GetQuestions().Count >= 0)
        {
            foreach (QuestionSerializable question in database.GetQuestions())
            {
                listOfQuestion += $"----------------\n{question.Question}\n{question.AnswearA}\n{question.AnswearB}\n{question.AnswearC}\n" +
                    $"{question.CorrectAnswear}\n{question.FirstFunFact}\n{question.SecondFunFact}\n{question.QuestionLevel}\n";
            }
        }else
        {
            listOfQuestion = "Brak pytañ";
        }

        panelQuestions.text = listOfQuestion;
    }
}
