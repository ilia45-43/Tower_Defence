using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public TMP_Text _textMoney;
    public int money;

    private int addedMoney;

    private void Start()
    {
        if (PlayerPrefs.HasKey("addedmoney"))
        {
            money += PlayerPrefs.GetInt("addedmoney");
        }
        _textMoney.text = money.ToString();
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        _textMoney.text = money.ToString();
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        _textMoney.text = money.ToString();
    }
}