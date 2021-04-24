using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    protected int price;
    protected string description;
    protected Sprite itemSprite;

    public abstract void Use();
}

public class SpeedBoost : Item
{
    public SpeedBoost()
    {
        price = 10;
        description = "This item boosts your diving speed significantly in a short period of time";
    }

    public override void Use()
    {

    }
}

public class Shield : Item
{
    public Shield()
    {
        price = 25;
        description = "This item protects you from attack of all creatures";
    }

    public override void Use()
    {
        Object.Instantiate(Resources.Load("Shield"));
    }
}

public class InkBomb : Item
{
    public InkBomb()
    {
        price = 15;
        description = "This item prevents creatures from seeing you";
    }

    public override void Use()
    {
        
    }
}

public class Meat : Item
{
    public Meat()
    {
        price = 15;
        description = "This piece of meat saves you from hungry creatures";
    }

    public override void Use()
    {
        Object.Instantiate(Resources.Load("Meat"));
    }
}