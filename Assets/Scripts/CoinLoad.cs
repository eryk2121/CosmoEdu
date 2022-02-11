using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinLoad : MonoBehaviour
{
    public Data dataBase;
    public Text coins;

    public void Update()
    {
        coins.text = dataBase.CurrentCoins.ToString();
    }
}
