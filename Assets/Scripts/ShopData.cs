using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    [SerializeField]
    Image healthProgresBar;
    [SerializeField]
    Image shieldProgresBar;
    [SerializeField]
    Image coinProgresBar;
    // Start is called before the first frame update
    void Start()
    {
        LoadShopData();
        PlayerPrefs.SetInt("HealthUpgrade", 0);
        PlayerPrefs.SetInt("ShieldUpgrade", 0);
        PlayerPrefs.SetInt("CoinUpgrade", 0);
    }

    private void LoadShopData()
    {
        healthProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("HealthUpgrade");
        shieldProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("ShieldUpgrade");
        coinProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("CoinUpgrade");
    }

    public void UpgradeHealth()
    {
        int level = PlayerPrefs.GetInt("HealthUpgrade");
        if (level < 5)
        {
            PlayerPrefs.SetInt("HealthUpgrade", level+1);
        }
        LoadShopData();
    }
    public void UpgradeShield()
    {
        int level = PlayerPrefs.GetInt("ShieldUpgrade");
        if (level < 5)
        {
            PlayerPrefs.SetInt("ShieldUpgrade", level + 1);
        }
        LoadShopData();
    }
    public void UpgradeCoin()
    {
        int level = PlayerPrefs.GetInt("CoinUpgrade");
        if (level < 5)
        {
            PlayerPrefs.SetInt("CoinUpgrade", level + 1);
        }
        LoadShopData();
    }
}
