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
        AudioManager.Instance.PlaySpeedBoost();
        Object.FindObjectOfType<PlayerMovement>().BoostSpeed();
    }
}

public class Shield : Item
{
    public Shield(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        AudioManager.Instance.PlayShieldActivation();
        Transform playerTransform = Object.FindObjectOfType<PlayerHealth>().transform;
        GameObject shield = (GameObject)Object.Instantiate(Resources.Load("Shield"), playerTransform);
        shield.transform.localPosition = new Vector3(0.04f, 0.07f);
    }
}

public class SmellyBomb : Item
{
    public SmellyBomb(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Transform playerTransform = Object.FindObjectOfType<PlayerHealth>().transform;
        GameObject explosion = (GameObject)Object.Instantiate(Resources.Load("SmellyExplosion"));
        explosion.transform.position = playerTransform.position;

        AudioManager.Instance.PlaySmellyBomb();
    }
}

public class Meat : Item
{
    public Meat(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Transform playerTransform = Object.FindObjectOfType<PlayerHealth>().transform;
        GameObject meat = (GameObject)Object.Instantiate(Resources.Load("Meat"));
        meat.transform.position = playerTransform.position;

        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - playerTransform.position;
        meat.GetComponent<MeatHandler>().FollowMouseDirection(shootDirection);

        AudioManager.Instance.PlayThrowingMeat();
    }
}

public class Rune : Item
{
    public Rune(Sprite sprite) : base(sprite) { }

    public override void Use()
    {
        Transform playerTransform = Object.FindObjectOfType<PlayerHealth>().transform;
        GameObject runExplosion = (GameObject)Object.Instantiate(Resources.Load("RuneExplosion"));
        runExplosion.transform.position = playerTransform.position;

        AudioManager.Instance.PlayRuneExplosion();
    }
}