﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class Quiz : MonoBehaviour
{

    private List<QuizElement> elements = new List<QuizElement>();

    public Text question;

    public Text ansA;
    public Text ansB;
    public Text ansC;

    public Image imgA;
    public Image imgB;
    public Image imgC;

    public Text tcounter;
    public int counter;

    public Ship ship;

    public Sprite correctAns;

    private string actualCorrect;
    public static string funFact;

    private int ansCode = 0;

    public void ZeroQuiz() {
        counterTime = DateTime.Now.Ticks;
        ansCode = 0;
    }

    private void Awake()
    {
        LoadQuestions();
    }

    private void Start()
    {
        ansCode = 0;
    }

    long time = DateTime.Now.Ticks;
    long counterTime = DateTime.Now.Ticks;

    private void Update()
    {
        if (DateTime.Now.Ticks - time >= 30000000 && ansCode == 1)
        {
            ship.ActiveEndPanel();
            time = DateTime.Now.Ticks;
        }
        else if (DateTime.Now.Ticks - time >= 30000000 && ansCode == 2)
        {
            ship.SoftRestart();
            time = DateTime.Now.Ticks;
        }

        counter = (int)(3 - ((DateTime.Now.Ticks - counterTime) / 10000000));
        tcounter.text = counter.ToString();

    }

    public void LoadElement()
    {
        Shuffle(elements);
        foreach (QuizElement q in elements)
        {
            if (!q.Used)
            {
                q.Used = true;

                question.text = q.Question;
                ansA.text = q.AnswerA;
                ansB.text = q.AnswerB;
                ansC.text = q.AnswerC;
                actualCorrect = q.Correct;
                funFact = q.FunFact;
                return;
            }
        }

        foreach (QuizElement q in elements)
        {
            q.Used = false;
        }

    }

    public void Shuffle(List<QuizElement> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            QuizElement value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void LoadQuestions()
    {

        var text = Resources.Load<TextAsset>("QuizData");
        Debug.Log(text);
        string[] data = text.text.Split('*');

        foreach (string s in data)
        {
            Debug.Log(s);
            string[] elementAsString = s.Split(':');
            elements.Add(new QuizElement(elementAsString[0], elementAsString[1], elementAsString[2], elementAsString[3], elementAsString[4], elementAsString[5]));
        }
    }

    SceneSwitch ss = new SceneSwitch();

    public void AChoosen() {
        time = DateTime.Now.Ticks;
        counterTime = DateTime.Now.Ticks;
        tcounter.gameObject.SetActive(true);
        if (actualCorrect.Equals("A"))
        {
            imgA.sprite = correctAns;
            ansCode = 2;
            CountCorrectAns();
        }
        else
        {
            ansCode = 1;
            ss.SwitchToFact();

        }

    }
    public void BChoosen() {
        time = DateTime.Now.Ticks;
        counterTime = DateTime.Now.Ticks;
        tcounter.gameObject.SetActive(true);
        if (actualCorrect.Equals("B"))
        {
            imgB.sprite = correctAns;
            ansCode = 2;
            CountCorrectAns();

        }
        else
        {
            ansCode = 1;
            ss.SwitchToFact();

        }

    }
    public void CChoosen() {
        time = DateTime.Now.Ticks;
        counterTime = DateTime.Now.Ticks;
        tcounter.gameObject.SetActive(true);
        if (actualCorrect.Equals("C"))
        {
            imgC.sprite = correctAns;
            ansCode = 2;
            CountCorrectAns();
        }
        else
        {
            ansCode = 1;
            ss.SwitchToFact();

        }
    }

    public void CountCorrectAns()
    {
        PlayerPrefs.SetInt("CorrectAnswer", PlayerPrefs.GetInt("CorrectAnswer") + 1);
        
    }
}
