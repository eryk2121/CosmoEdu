using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Data dataBase;
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
        LoadShopData();
    }

    public void BuyShip1() //funkcja odpowiadająca za zakup skórki
    {
        if (PlayerPrefs.GetInt("Ship1B")==1) //jeżeli wygląd jest już posiadany, ustawiamy go jako aktywny
        {
            PlayerPrefs.SetString("Ship", "Ship1");
            PlayerPrefs.SetInt("Ship1B", 1);
        }
        else if (Buy(100)) //jeżeli wygląd nie jest posiadany kupujemy go
        {
          PlayerPrefs.SetString("Ship", "Ship1");
          PlayerPrefs.SetInt("Ship1B", 1);

        }
        LoadShopData();
    }


    public void BuyShip2()
    {
        if (PlayerPrefs.GetInt("Ship2B")==1)
        {
            PlayerPrefs.SetString("Ship", "Ship2");
            PlayerPrefs.SetInt("Ship2B", 1);
        }
        else if (Buy(200))
        {
          PlayerPrefs.SetString("Ship", "Ship1");
          PlayerPrefs.SetInt("Ship2B", 1);

        }
        LoadShopData();
    }

    public void BuyShip3()
    {
        if (PlayerPrefs.GetInt("Ship3B")==1)
        {
            PlayerPrefs.SetString("Ship", "Ship1");
            PlayerPrefs.SetInt("Ship3B", 1);
        }
        else if (Buy(400))
        {
          PlayerPrefs.SetString("Ship", "Ship1");
          PlayerPrefs.SetInt("Ship3B", 1);

        }
        LoadShopData();
    }

    public void BuyShip4()
    {
        if (PlayerPrefs.GetInt("Ship4B")==1)
        {
            PlayerPrefs.SetString("Ship", "Ship4");
            PlayerPrefs.SetInt("Ship4B", 1);
        }
        else if (Buy(800))
        {
          PlayerPrefs.SetString("Ship", "Ship4");
          PlayerPrefs.SetInt("Ship4B", 1);

        }
        LoadShopData();
    }

    public void BuyShip5()
    {
        if (PlayerPrefs.GetInt("Ship5B")==1)
        {
            PlayerPrefs.SetString("Ship", "Ship5");
            PlayerPrefs.SetInt("Ship5B", 1);
        }
        else if (Buy(1600))
        {
          PlayerPrefs.SetString("Ship", "Ship5");
          PlayerPrefs.SetInt("Ship5B", 1);

        }
        LoadShopData();
    }

 

    private bool Buy(int cost)
    {
        if (dataBase.CurrentCoins >= cost)
        {
            dataBase.CurrentCoins -= cost;

            return true;
        }
        return false;
    }


}
