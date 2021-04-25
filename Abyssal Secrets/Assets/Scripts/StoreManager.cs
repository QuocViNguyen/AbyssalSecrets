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
    [SerializeField] PlayerMoney playerMoney;

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
        if (!playerMoney.CheckEnoughMoney(bootPrice))
            return;

        if (itemManager.AddItem(new SpeedBoost(speedBoostSprite)))
            playerMoney.UseMoney(bootPrice);
    }

    public void BuyScent()
    {
        if (!playerMoney.CheckEnoughMoney(scentPrice))
            return;

        if (itemManager.AddItem(new SmellyBomb(smellyBombSprite)))
            playerMoney.UseMoney(scentPrice);
    }

    public void BuyMeat()
    {
        if (!playerMoney.CheckEnoughMoney(meatPrice))
            return;

        if (itemManager.AddItem(new Meat(meatSprite)))
            playerMoney.UseMoney(meatPrice);
    }

    public void BuyShield()
    {
        if (!playerMoney.CheckEnoughMoney(shieldPrice))
            return;

        if (itemManager.AddItem(new Shield(shieldSprite)))
            playerMoney.UseMoney(shieldPrice);
    }

    public void BuyRune()
    {
        if (!playerMoney.CheckEnoughMoney(runePrice))
            return;

        if (itemManager.AddItem(new Rune(runeSprite)))
            playerMoney.UseMoney(runePrice);
    }
}
