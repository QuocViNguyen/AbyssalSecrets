using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] Sprite speedBoostSprite;
    [SerializeField] Sprite smellyBombSprite;
    [SerializeField] Sprite meatSprite;
    [SerializeField] Sprite shieldSprite;
    [SerializeField] Sprite runeSprite;

    [SerializeField] Text bootPriceTxt;
    [SerializeField] Text scentPriceTxt;
    [SerializeField] Text meatPriceTxt;
    [SerializeField] Text shieldPriceTxt;
    [SerializeField] Text runePriceTxt;

    [SerializeField] ItemManager itemManager;

    private int bootPrice = 10; 
    private int scentPrice = 15; 
    private int meatPrice = 15; 
    private int shieldPrice = 25; 
    private int runePrice = 200;

    // Start is called before the first frame update
    void Awake()
    {
        bootPriceTxt.text = bootPrice.ToString();
        scentPriceTxt.text = scentPrice.ToString();
        meatPriceTxt.text = meatPrice.ToString();
        shieldPriceTxt.text = shieldPrice.ToString();
        runePriceTxt.text = runePrice.ToString();
    }

    public void BuyBoot()
    {
        if (!CheckMoney(bootPrice))
            return;

        if (itemManager.AddItem(new SpeedBoost(speedBoostSprite)))
            return;
    }

    private bool CheckMoney(int price)
    {
        return true;
    }

    public void BuyScent()
    {
        if (!CheckMoney(scentPrice))
            return;

        if (itemManager.AddItem(new SmellyBomb(smellyBombSprite)))
            return;
    }

    public void BuyMeat()
    {
        if (!CheckMoney(meatPrice))
            return;

        if (itemManager.AddItem(new Meat(meatSprite)))
            return;
    }

    public void BuyShield()
    {
        if (!CheckMoney(shieldPrice))
            return;

        if (itemManager.AddItem(new Shield(shieldSprite)))
            return;
    }

    public void BuyRune()
    {
        if (!CheckMoney(runePrice))
            return;

        if (itemManager.AddItem(new Rune(runeSprite)))
            return;
    }
}
