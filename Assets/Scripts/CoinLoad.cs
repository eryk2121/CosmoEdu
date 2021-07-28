using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinLoad : MonoBehaviour
{
    public Text coins;
    // Start is called before the first frame update
    void Start()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void UpdateCoins()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

}
