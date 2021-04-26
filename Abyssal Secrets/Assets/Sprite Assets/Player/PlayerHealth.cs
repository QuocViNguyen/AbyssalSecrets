using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] GameObject gameOver;
    public float currentHealth;

    [SerializeField] Healthbar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnDamageTaken(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
