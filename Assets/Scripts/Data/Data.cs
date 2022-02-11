using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa która reprezentuje model bazy danych
[CreateAssetMenu(fileName = "Data", menuName = "CreateData")]
public class Data : ScriptableObject
{
    [field: SerializeField]
    public int AmountOfPlay { get; set; } 
    [field: SerializeField]
    public int CorrectAnserwrs { get; set; } /
    [field: SerializeField]
    public int HighScore { get; set; } 
    [field: SerializeField]
    public List<QuestionSerializable> Questions { get; set; } = new List<QuestionSerializable>(); // Storzone przez nas pytania
    [field: SerializeField]
    public List<QuestionSerializable> DefaultQuestions { get; set; } = new List<QuestionSerializable>(); //Defaultowe Pytania
    [field: SerializeField]
    public int CurrentCoins { get; set; } 
    [field: SerializeField]
    public List<int> BestScores { get; set; } = new List<int>();  // Najlepsze score 

    public int LastAddedCoins { get; set; } // Ostatnie zdobyte coinsy,  potrzebne do wyœwietlenia po zakonczeniu gry 
    public int LastAchievedScore { get; set; } // Ostatnie zdobyte punkty, potrzebne do porównania HighScore  

    // Pobieranie pytan do wyœwietlenia
    public List<QuestionSerializable> GetQuestions()
    {
        List<QuestionSerializable> allQuestions = new List<QuestionSerializable>();

        allQuestions.AddRange(DefaultQuestions);
        allQuestions.AddRange(Questions);

        return allQuestions;
    }

    // Odczyt danych
    public void LoadData(string path)
    {
        SaveManager.Instance.Load<DataSerializable>(path, OnCompleteLoadData, true);
    }

    // Zapis danych
    public void SaveData(string path)
    {
        DataSerializable dataSerializable = new DataSerializable();
        dataSerializable.AmountOfPlay = AmountOfPlay;
        dataSerializable.CorrectAnserwrs = CorrectAnserwrs;
        dataSerializable.HighScore = HighScore;
        dataSerializable.Questions = Questions;
        dataSerializable.CurrentCoins = CurrentCoins;
        dataSerializable.BestScores = BestScores;

        SaveManager.Instance.Save<DataSerializable>(dataSerializable, path, OnCompleteSaveData, true);
    }


    private void OnCompleteSaveData(SaveResult saveResult, string arg1)
    {
        if (saveResult == SaveResult.Success)
        {
            Debug.Log("Zapisa³em Dane");
        }
        else if (saveResult == SaveResult.Error)
        {
            Debug.LogError("Zapis siê nie uda³");
        }
    }

    private void OnCompleteLoadData(DataSerializable loadedData, SaveResult loadResult, string arg2)
    {
        if(loadResult == SaveResult.Success)
        {
            AmountOfPlay = loadedData.AmountOfPlay;
            CorrectAnserwrs = loadedData.CorrectAnserwrs;
            HighScore = loadedData.HighScore;

            if (loadedData.Questions != null)
            {
                Questions = loadedData.Questions;
            }

            if(loadedData.BestScores != null)
            {
                BestScores = loadedData.BestScores;
            }

            CurrentCoins = loadedData.CurrentCoins;

            Debug.Log("Odczyta³em dane");
        }
        else if(loadResult == SaveResult.Error)
        {
            Debug.LogError("Nie odczyta³em dane");
        }
    }

    // Reset wszystkich danych
    public void ResetData()
    {
        AmountOfPlay = 0;
        CorrectAnserwrs = 0;
        HighScore = 0;
        Questions.Clear();
        CurrentCoins = 0;

        PlayerPrefs.SetInt("Ship1B", 0);
        PlayerPrefs.SetInt("Ship2B", 0);
        PlayerPrefs.SetInt("Ship3B", 0);
        PlayerPrefs.SetInt("Ship4B", 0);
        PlayerPrefs.SetInt("Ship5B", 0);

        PlayerPrefs.SetInt("HealthUpgrade", 0);
        PlayerPrefs.SetInt("ShieldUpgrade", 0);
        PlayerPrefs.SetInt("CoinUpgrade", 0);
        PlayerPrefs.SetInt("WeaponUpgrade", 0);
        PlayerPrefs.SetInt("FreezeUpgrade", 0);

        PlayerPrefs.SetString("Ship", "Ship1");
    }

    // Dodanie scora to tablicy wyników - próba
    public void TryToAddScoreScoreboard(int score)
    {
        BestScores.Add(score);
        BestScores.Sort();

        if(BestScores.Count == 6)
        {
            BestScores.RemoveAt(0);
        }
    }
}


[System.Serializable]
public class DataSerializable
{
    public int AmountOfPlay;
    public int CorrectAnserwrs;
    public int HighScore;
    public List<QuestionSerializable> Questions;
    public int CurrentCoins;
    public List<int> BestScores;
}


[System.Serializable]
public class QuestionSerializable
{
    public string Question;
    public string AnswearA;
    public string AnswearB;
    public string AnswearC;
    public string CorrectAnswear;
    public string FirstFunFact;
    public string SecondFunFact;
    public int QuestionLevel;

    public QuestionSerializable(string question, string answearA, string answearB, string answearC, string correctAnswear, string firstFunFact, string secondFunFact, int questionLevel)
    {
        Question = question;
        AnswearA = answearA;
        AnswearB = answearB;
        AnswearC = answearC;
        CorrectAnswear = correctAnswear;
        FirstFunFact = firstFunFact;
        SecondFunFact = secondFunFact;
        QuestionLevel = questionLevel;
    }
}
