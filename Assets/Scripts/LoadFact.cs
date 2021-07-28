﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadFact : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Text fact;
    public Text coin;
    public Text score;
    private void Start()
    {
        fact.text = Quiz.funFact;
        LoadCoins();
        LoadScore();
    }
    public void SwitchPanel() {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void LoadCoins()
    {
        coin.text = Ship.coins.ToString();
    }
    public void LoadScore()
    {
        score.text = Ship.score.ToString();
    }
}
