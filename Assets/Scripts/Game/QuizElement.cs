using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizElement
{

    string question;
    string answerA;
    string answerB;
    string answerC;
    string correct;
    string funFactFirst;
    string funFactSecond;
    int questionLevel;
    bool used = false;

    public QuizElement(string question, string answerA, string answerB, string answerC, string correct, string funFactFirst, string funFactSecond, int questionLevel)
    {
        this.question = question;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.correct = correct;
        this.funFactFirst = funFactFirst;
        this.funFactSecond = funFactSecond;
        this.questionLevel = questionLevel;
    }

    public string Question { get => question; set => question = value; }
    public string AnswerA { get => answerA; set => answerA = value; }
    public string AnswerB { get => answerB; set => answerB = value; }
    public string AnswerC { get => answerC; set => answerC = value; }
    public bool Used { get => used; set => used = value; }
    public string Correct { get => correct; set => correct = value; }
    public string FunFactFirst { get => funFactFirst; set => funFactFirst = value; }
    public string FunFactSecond { get => funFactSecond; set => funFactSecond = value; }
    public int QuestionLevel { get => questionLevel; set => questionLevel = value; }

}