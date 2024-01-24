using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopMenuUI : MonoBehaviour
{
    #region parametrs
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject uiMenu;
    [SerializeField] private GameObject cantMenu;

    public int _money;

    public int priceOf1gun = 100;
    public int priceOf2gun = 200;
    public int priceOf3gun = 400;

    [SerializeField] private GameObject prefab1Gun;
    [SerializeField] private GameObject prefab2Gun;
    [SerializeField] private GameObject prefab3Gun;

    private List<string> isbought1;
    private List<string> isbought2;
    private List<string> isbought3;

    [SerializeField] private Transform _place1Gun;
    [SerializeField] private Transform _place2Gun;
    [SerializeField] private Transform _place3Gun;
    #endregion

    private void Start()
    {
        isbought1 = new List<string>();
        isbought2 = new List<string>();
        isbought3 = new List<string>();

        priceOf1gun = 100;
        priceOf2gun = 200;
        priceOf3gun = 400;
    }
    public void OpenShopMenu()
    {
        shopMenu.SetActive(true);
        uiMenu.SetActive(false);
    }

    public void CloseShopMenu()
    {
        shopMenu.SetActive(false);
        uiMenu.SetActive(true);
    }

    public void Buy1Gun(int f)
    {
        _money = GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().GetMoney();
        if (_money < priceOf1gun)
        {
            cantMenu.SetActive(true);
            return;
        }
        if (f == 1)
        {
            if (!isbought1.Contains("Tyrret1"))
                CheckPlace1(f);
        }
        else if (f == 2)
        {
            if (!isbought2.Contains("Tyrret1"))
                CheckPlace1(f);
        }
        else if (f == 3)
        {
            if (!isbought3.Contains("Tyrret1"))
                CheckPlace1(f);
        }
    }

    private void CheckPlace1(int f)
    {
        switch (f)
        {
            case 1:
                if (isbought1.Count != 0)
                {
                    isbought1.Clear();
                    Destroy(_place1Gun.GetChild(0).gameObject);
                }
                var a = Instantiate(prefab1Gun, _place1Gun.position, Quaternion.identity);
                a.transform.SetParent(_place1Gun);
                isbought1.Add("Tyrret1");
                break;
            case 2:
                if (isbought2.Count != 0)
                {
                    isbought2.Clear();
                    Destroy(_place2Gun.GetChild(0).gameObject);
                }
                var b = Instantiate(prefab1Gun, _place2Gun.position, Quaternion.identity);
                b.transform.SetParent(_place2Gun);
                isbought2.Add("Tyrret1");
                break;
            case 3:
                if (isbought3.Count != 0)
                {
                    isbought3.Clear();
                    Destroy(_place3Gun.GetChild(0).gameObject);
                }
                var c = Instantiate(prefab1Gun, _place3Gun.position, Quaternion.identity);
                c.transform.SetParent(_place3Gun);
                isbought3.Add("Tyrret1");
                break;
        }
        GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().RemoveMoney(priceOf1gun);
    }

    public void Buy2Gun(int f)
    {
        _money = GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().GetMoney();
        if (_money < priceOf2gun)
        {
            cantMenu.SetActive(true);
            return;
        }
        if (f == 1)
        {
            if (!isbought1.Contains("Tyrret2"))
                CheckPlace2(f);
        }
        else if (f == 2)
        {
            if (!isbought2.Contains("Tyrret2"))
                CheckPlace2(f);
        }
        else if (f == 3)
        {
            if (!isbought3.Contains("Tyrret2"))
                CheckPlace2(f);
        }
    }

    private void CheckPlace2(int f)
    {
        switch (f)
        {
            case 1:
                if (isbought1.Count != 0)
                {
                    isbought1.Clear();
                    Destroy(_place1Gun.GetChild(0).gameObject);
                }
                var a = Instantiate(prefab2Gun, _place1Gun.position, Quaternion.identity);
                a.transform.SetParent(_place1Gun);
                isbought1.Add("Tyrret2");
                break;
            case 2:
                if (isbought2.Count != 0)
                {
                    isbought2.Clear();
                    Destroy(_place2Gun.GetChild(0).gameObject);
                }
                var b = Instantiate(prefab2Gun, _place2Gun.position, Quaternion.identity);
                b.transform.SetParent(_place2Gun);
                isbought2.Add("Tyrret2");
                break;
            case 3:
                if (isbought3.Count != 0)
                {
                    isbought3.Clear();
                    Destroy(_place3Gun.GetChild(0).gameObject);
                }
                var c = Instantiate(prefab2Gun, _place3Gun.position, Quaternion.identity);
                c.transform.SetParent(_place3Gun);
                isbought3.Add("Tyrret2");
                break;
        }
        GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().RemoveMoney(priceOf2gun);
    }

    public void Buy3Gun(int f)
    {
        _money = GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().GetMoney();
        if (_money < priceOf3gun)
        {
            cantMenu.SetActive(true);
            return;
        }
        if (f == 1)
        {
            if (!isbought1.Contains("Tyrret3"))
                CheckPlace3(f);
        }
        else if (f == 2)
        {
            if (!isbought2.Contains("Tyrret3"))
                CheckPlace3(f);
        }
        else if (f == 3)
        {
            if (!isbought3.Contains("Tyrret3"))
                CheckPlace3(f);
        }
    }

    private void CheckPlace3(int f)
    {
        switch (f)
        {
            case 1:
                if (isbought1.Count != 0)
                {
                    isbought1.Clear();
                    Destroy(_place1Gun.GetChild(0).gameObject);
                }
                var a = Instantiate(prefab3Gun, _place1Gun.position, Quaternion.identity);
                a.transform.SetParent(_place1Gun);
                isbought1.Add("Tyrret3");
                break;
            case 2:
                if (isbought2.Count != 0)
                {
                    isbought2.Clear();
                    Destroy(_place2Gun.GetChild(0).gameObject);
                }
                var b = Instantiate(prefab3Gun, _place2Gun.position, Quaternion.identity);
                b.transform.SetParent(_place2Gun);
                isbought2.Add("Tyrret3");
                break;
            case 3:
                if (isbought3.Count != 0)
                {
                    isbought3.Clear();
                    Destroy(_place3Gun.GetChild(0).gameObject);
                }
                var c = Instantiate(prefab3Gun, _place3Gun.position, Quaternion.identity);
                c.transform.SetParent(_place3Gun);
                isbought3.Add("Tyrret3");
                break;
        }
        GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>().RemoveMoney(priceOf3gun);
    }
}