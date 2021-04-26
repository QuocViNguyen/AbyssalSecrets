using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float damage = 5.0f;
    [SerializeField] float attackRate = 2.0f;

    private PlayerHealth targetHealth;
    private float lastAttackTime;
    private bool faded;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHealth != null && !faded)
        {
            if (Time.time - lastAttackTime >= attackRate)
            {
                lastAttackTime = Time.time;
                targetHealth.OnDamageTaken(damage);
            }
        }

        if (faded)
        {
            Color color = spriteRenderer.color;
            spriteRenderer.color = Color.Lerp(color, new Color(color.r, color.g, color.b, 0), Time.deltaTime * 0.3f);
            if (spriteRenderer.color.a == 0.0f)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targetHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (gameObject.tag == "Bomb")
            {
                collision.gameObject.GetComponent<PlayerHealth>().OnDamageTaken(damage);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targetHealth = null;
        }
    }

    public void OnExplosion()
    {
        if (tag == "Kraken")
        {
            AudioManager.Instance.PlayGrowl();
            faded = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
