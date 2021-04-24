using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    [SerializeField] Healthbar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void OnHealthChanged(int newHealth)
    {
        healthBar.SetHealth(newHealth);
        currentHealth = newHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnHealthChanged(currentHealth - 20);
        }
    }
}
