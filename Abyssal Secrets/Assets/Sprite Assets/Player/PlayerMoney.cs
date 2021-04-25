using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private const string Key = "Money";
    private int money = 5000;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            money = PlayerPrefs.GetInt(Key);
            Debug.Log(money);
        }
    }

    public bool CheckEnoughMoney(int price)
    {
        return money >= price;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        PlayerPrefs.SetInt(Key, money);
    }

    public void UseMoney(int amount)
    {
        money -= amount;
        Debug.Log(money);
        PlayerPrefs.SetInt(Key, money);
    }
}
