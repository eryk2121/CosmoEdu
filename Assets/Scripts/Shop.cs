using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Image ship1;
    public Image ship2;
    public Image ship3;
    public Image ship4;
    public Image ship5;

    public void LoadShopData()
    {
        if (PlayerPrefs.GetInt("Ship1B") == 1)
        {
            ship1.color = new Color32(100, 100, 90, 225);
        }
        if (PlayerPrefs.GetInt("Ship2B") == 1)
        {
            ship2.color = new Color32(100, 100, 90, 225);
        }
        if (PlayerPrefs.GetInt("Ship3B") == 1)
        {
            ship3.color = new Color32(100, 100, 90, 225);
        }
        if (PlayerPrefs.GetInt("Ship4B") == 1)
        {
            ship4.color = new Color32(100, 100, 90, 225);
        }
        if (PlayerPrefs.GetInt("Ship5B") == 1)
        {
            ship5.color = new Color32(100, 100, 90, 225);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("CorrectAnswer", 0);
        PlayerPrefs.SetInt("Ship1B", 1);
        PlayerPrefs.SetInt("Ship2B", 0);
        PlayerPrefs.SetInt("Ship3B", 0);
        PlayerPrefs.SetInt("Ship4B", 0);
        PlayerPrefs.SetInt("Ship5B", 0);
        LoadShopData();
    }

    public void BuyShip1()
    {
        if (PlayerPrefs.GetInt("Ship1B")==1 || Buy(100))
        {
            Gamedata gd = FindObjectOfType<Gamedata>();
            PlayerPrefs.SetString("Ship", "Ship1");
            PlayerPrefs.SetInt("Ship1B", 1);
        }
        LoadShopData();

    }

    public void BuyShip2()
    {
        if (PlayerPrefs.GetInt("Ship2B") == 1 || Buy(200))
        {
            Gamedata gd = FindObjectOfType<Gamedata>();
            PlayerPrefs.SetString("Ship", "Ship2");
            PlayerPrefs.SetInt("Ship2B", 1);

        }
        LoadShopData();

    }

    public void BuyShip3()
    {
        if (PlayerPrefs.GetInt("Ship3B") == 1 || Buy(300))
        {
            Gamedata gd = FindObjectOfType<Gamedata>();
            PlayerPrefs.SetString("Ship", "Ship3");
            PlayerPrefs.SetInt("Ship3B", 1);

        }
        LoadShopData();

    }

    public void BuyShip4()
    {
        if (PlayerPrefs.GetInt("Ship4B") == 1 || Buy(400))
        {
            Gamedata gd = FindObjectOfType<Gamedata>();
            PlayerPrefs.SetString("Ship", "Ship4");
            PlayerPrefs.SetInt("Ship4B", 1);

        }
        LoadShopData();

    }

    public void BuyShip5()
    {
        if (PlayerPrefs.GetInt("Ship5B") == 1 || Buy(500))
        {
            Gamedata gd = FindObjectOfType<Gamedata>();
            PlayerPrefs.SetString("Ship", "Ship5");
            PlayerPrefs.SetInt("Ship5B", 1);

        }
        LoadShopData();

    }

    private bool Buy()
    {
        if (PlayerPrefs.GetInt("Coins") >= 100)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-100);

            return true;
        }
        return false; 
    }

    private bool Buy(int cost)
    {
        if (PlayerPrefs.GetInt("Coins") >= cost)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - cost);

            return true;
        }
        return false;
    }


}
