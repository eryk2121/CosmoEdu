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
    [SerializeField]
    Image weaponProgresBar;

    [SerializeField]
    CoinLoad coinLoad;

    // Start is called before the first frame update
    void Start()
    {
        LoadShopData();
    }

    private void LoadShopData()
    {
        healthProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("HealthUpgrade");
        shieldProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("ShieldUpgrade");
        coinProgresBar.fillAmount = 0.2f*PlayerPrefs.GetInt("CoinUpgrade");
        weaponProgresBar.fillAmount = 0.2f * PlayerPrefs.GetInt("WeaponUpgrade");
    }

    public void UpgradeHealth()
    {
        int level = PlayerPrefs.GetInt("HealthUpgrade");
        if (level < 5 && Buy())
        {
            PlayerPrefs.SetInt("HealthUpgrade", level+1);
        }
        LoadShopData();
    }
    public void UpgradeShield()
    {
        int level = PlayerPrefs.GetInt("ShieldUpgrade");
        if (level < 5 && Buy())
        {
            PlayerPrefs.SetInt("ShieldUpgrade", level + 1);
        }
        LoadShopData();
    }
    public void UpgradeCoin()
    {
        int level = PlayerPrefs.GetInt("CoinUpgrade");
        if (level < 5 && Buy())
        {
            PlayerPrefs.SetInt("CoinUpgrade", level + 1);
        }
        LoadShopData();
    }
    public void UpgradeWeapon()
    {
        int level = PlayerPrefs.GetInt("WeaponUpgrade");
        if (level < 5 && Buy())
        {
            PlayerPrefs.SetInt("WeaponUpgrade", level + 1);
        }
        LoadShopData();
    }

    private bool Buy()
    {
        if (PlayerPrefs.GetInt("Coins") >= 100)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);

            coinLoad.UpdateCoins();
            return true;
        }
        return false;
    }
}
