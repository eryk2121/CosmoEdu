using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using System;

public class QuestionAddButton : MonoBehaviour
{
    public Data database;
    public Text question;
    public Text ansA;
    public Text ansB;
    public Text ansC;
    public Text correct;
    public Text firstfunfact;
    public Text secondfunfact;
    public Text questionLevel;


    public void AddQuestion()
    {
        QuestionSerializable questionToSave = new QuestionSerializable(question.text, ansA.text, ansB.text, ansC.text, correct.text, firstfunfact.text, secondfunfact.text, Int32.Parse(questionLevel.text));

        database.Questions.Add(questionToSave);

        question.transform.parent.GetComponent<InputField>().text = String.Empty;
        ansA.transform.parent.GetComponent<InputField>().text = String.Empty;
        ansB.transform.parent.GetComponent<InputField>().text = String.Empty;
        ansC.transform.parent.GetComponent<InputField>().text = String.Empty;
        correct.transform.parent.GetComponent<InputField>().text = String.Empty;
        firstfunfact.transform.parent.GetComponent<InputField>().text = String.Empty;
        secondfunfact.transform.parent.GetComponent<InputField>().text = String.Empty;
        questionLevel.transform.parent.GetComponent<InputField>().text = String.Empty;
    }
}
