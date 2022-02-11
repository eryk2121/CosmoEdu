using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Quiz : MonoBehaviour
{
    public Data dataBase;
    private List<QuizElement> elements = new List<QuizElement>();

    public int questionLevel;


    public Text question;

    public Text ansA;
    public Text ansB;
    public Text ansC;

    public Image imgA;
    public Image imgB;
    public Image imgC;

    public Text tcounter; //licznik czasu
    public int counter; //licznik czasu

    public Ship ship; //statek, sprawdzmy jego punkty

    public static QuizElement choosen; // wybrane pytanie

    public Sprite correctAns; //podmieninanea grafika na zieloną, tutaj jest podtrzymywana

    private string actualCorrect; //prawdiłowa odpowiedź
    public static string funFact;

    private int ansCode = 0; //0=a,1=2

    public void ZeroQuiz()
    {//zeruje quiz
        counterTime = DateTime.Now.Ticks;
        ansCode = 0;
    }


    private void Start()
    {
        ansCode = 0;
    }

    long time = DateTime.Now.Ticks; //czas do odliczania
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

    public void LoadElement(int level)
    {
        LoadQuestions();
        List<QuizElement> quizElementsWithCorrectLevel = elements.Where(question => question.QuestionLevel == level).ToList();

        QuizElement quizElement = RandomElement(quizElementsWithCorrectLevel);

        choosen = quizElement;
        question.text = quizElement.Question;
        ansA.text = quizElement.AnswerA;
        ansB.text = quizElement.AnswerB;
        ansC.text = quizElement.AnswerC;
        actualCorrect = quizElement.Correct;
        questionLevel = quizElement.QuestionLevel;

        RandomFunFact(quizElement);
    }

    public QuizElement RandomElement(List<QuizElement> list)
    {
        return list.ElementAt(new System.Random(DateTime.Now.Millisecond).Next(list.Count()));
    }

    private void LoadQuestions()
    {
        elements.Clear();

        foreach (QuestionSerializable questionData in dataBase.GetQuestions())
        {
            elements.Add(new QuizElement(questionData.Question, questionData.AnswearA, questionData.AnswearB, questionData.AnswearC, questionData.CorrectAnswear, questionData.FirstFunFact, questionData.SecondFunFact, questionData.QuestionLevel));
        }
    }

    SceneSwitch ss = new SceneSwitch();

    public void AChoosen()
    {
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
            SaveUserScore();
            ansCode = 1;
            ss.SwitchToFact();
        }

    }
    public void BChoosen()
    {
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
            SaveUserScore();
            ansCode = 1;
            ss.SwitchToFact();

        }

    }
    public void CChoosen()
    {
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
            SaveUserScore();
            ansCode = 1;
            ss.SwitchToFact();

        }
    }

    public void CountCorrectAns()
    {
        dataBase.CorrectAnserwrs++;
    }

    public void SaveUserScore()
    {
        dataBase.AmountOfPlay += 1;
        ship.UpdateHighScore();
        ship.AddCoins();
    }

    private void RandomFunFact(QuizElement quizElement)
    {
        System.Random rand = new System.Random();
        int number = rand.Next(0, 100);

        if (number > 50)
        {
            funFact = quizElement.FunFactFirst;
        }
        else
        {
            funFact = quizElement.FunFactSecond;
        }
    }
}
