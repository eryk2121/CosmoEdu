using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    //Inicjalizacja zmiennych przy pierwszym uruchomieniu
    void Start()
    {
        if (!PlayerPrefs.HasKey("HealthUpgrade"))
        {
            PlayerPrefs.SetInt("HealthUpgrade", 0);
        }
        if (!PlayerPrefs.HasKey("ShieldUpgrade"))
        {
            PlayerPrefs.SetInt("ShieldUpgrade", 0);
        }
        if (!PlayerPrefs.HasKey("CoinUpgrade"))
        {
            PlayerPrefs.SetInt("CoinUpgrade", 0);
        }
        if (!PlayerPrefs.HasKey("WeaponUpgrade"))
        {
            PlayerPrefs.SetInt("WeaponUpgrade", 0);
        }

        if (!PlayerPrefs.HasKey("FreezeUpgrade"))
        {
            PlayerPrefs.SetInt("FreezeUpgrade", 0);
        }

        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }

        if (!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }
        if (!PlayerPrefs.HasKey("CorrectAnswer"))
        {
            PlayerPrefs.SetInt("CorrectAnswer", 0);
        }
        if (!PlayerPrefs.HasKey("GamesAmount"))
        {
            PlayerPrefs.SetInt("GamesAmount", 0);
        }


        if (!PlayerPrefs.HasKey("Ship1B"))
        {
            PlayerPrefs.SetInt("Ship1B", 0);
        }
        if (!PlayerPrefs.HasKey("Ship2B"))
        {
            PlayerPrefs.SetInt("Ship2B", 0);
        }
        if (!PlayerPrefs.HasKey("Ship3B"))
        {
            PlayerPrefs.SetInt("Ship3B", 0);
        }
        if (!PlayerPrefs.HasKey("Ship4B"))
        {
            PlayerPrefs.SetInt("Ship4B", 0);
        }
        if (!PlayerPrefs.HasKey("Ship5B"))
        {
            PlayerPrefs.SetInt("Ship5B", 0);
        }
    }
}
