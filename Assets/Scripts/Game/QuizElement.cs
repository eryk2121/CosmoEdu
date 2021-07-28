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
    string funFact;
    bool used = false;

    public QuizElement(string question, string answerA, string answerB, string answerC, string correct, string funFact)
    {
        this.question = question;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.correct = correct;
        this.funFact = funFact;
    }

    public string Question { get => question; set => question = value; }
    public string AnswerA { get => answerA; set => answerA = value; }
    public string AnswerB { get => answerB; set => answerB = value; }
    public string AnswerC { get => answerC; set => answerC = value; }
    public bool Used { get => used; set => used = value; }
    public string Correct { get => correct; set => correct = value; }
    public string FunFact { get => funFact; set => funFact = value; }

}
