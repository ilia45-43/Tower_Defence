using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Variables")]
    public int _diamond;
    public int priceForStartMoney;
    public int addedMoney;
    public int priceForPlusHeart;

    [Header("-----UI-----")]
    public GameObject shopPanelUI;
    public GameObject gunPlacesUI;
    public TMP_Text diamondText;
    public GameObject cantMenu;

    public void OpenShopMenu()
    {
        if(PlayerPrefs.HasKey("diamonds"))
        {
            diamondText.text = "DIAMONDS: " + PlayerPrefs.GetInt("diamonds").ToString();
        }
        else
        {
            diamondText.text = "DIAMONDS: 0";
        }
        shopPanelUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseShopMenu()
    {
        shopPanelUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyStartMoney()
    {
        SetDiamonds();
        if (_diamond >= priceForStartMoney)
        {
            _diamond -= priceForStartMoney;
            PlayerPrefs.SetInt("diamonds", _diamond);
            PlayerPrefs.Save();
            diamondText.text = "DIAMONDS: " + _diamond.ToString();

            if (PlayerPrefs.HasKey("addedmoney"))
            {
                PlayerPrefs.SetInt("addedmoney", addedMoney + PlayerPrefs.GetInt("addedmoney"));
                PlayerPrefs.Save();
            }
            else
            {
                PlayerPrefs.SetInt("addedmoney", addedMoney);
                PlayerPrefs.Save();
            }
        }
        else
        {
            cantMenu.SetActive(true);
        }
    }

    public void BuyStartHeart()
    {
        SetDiamonds();
        if (_diamond >= priceForPlusHeart)
        {
            _diamond -= priceForStartMoney;
            PlayerPrefs.SetInt("diamonds", _diamond);
            PlayerPrefs.Save();
            diamondText.text = "DIAMONDS: " + _diamond.ToString();

            GameObject.FindGameObjectWithTag("HeartSystem").GetComponent<FinishGame>().SetHearts(1);
        }
        else
        {
            cantMenu.SetActive(true);
        }
    }

    private void SetDiamonds()
    {
        if (PlayerPrefs.HasKey("diamonds"))
        {
            _diamond = PlayerPrefs.GetInt("diamonds");
        }
        else
        {
            _diamond = 0;
        }
    }
}