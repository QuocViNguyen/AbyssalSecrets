using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public Sprite ItemSprite { get; private set; }

    protected Item(Sprite sprite)
    {
        ItemSprite = sprite;
    }

    public abstract void Use();
}

public class SpeedBoost : Item
{
    public SpeedBoost(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Debug.Log("SpeedBoost used");
    }
}

public class Shield : Item
{
    public Shield(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Object.Instantiate(Resources.Load("Shield"));
    }
}

public class SmellyBomb : Item
{
    public SmellyBomb(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Debug.Log("SmellyBomb used");
    }
}

public class Meat : Item
{
    public Meat(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Object.Instantiate(Resources.Load("Meat"));
    }
}

public class Rune : Item
{
    public Rune(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Debug.Log("Rune used");
    }
}