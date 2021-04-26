using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float damage = 5.0f;
    [SerializeField] float attackRate = 2.0f;

    private PlayerHealth targetHealth;
    private float lastAttackTime;

    // Update is called once per frame
    void Update()
    {
        if (targetHealth != null)
        {
            if (Time.time - lastAttackTime >= attackRate)
            {
                lastAttackTime = Time.time;
                targetHealth.OnDamageTaken(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targetHealth = collision.gameObject.GetComponent<PlayerHealth>();
        }
        if (gameObject.tag == "Bomb")
        {
            collision.gameObject.GetComponent<PlayerHealth>().OnDamageTaken(damage);
            //gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targetHealth = null;
        }
    }
}
