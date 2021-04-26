using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] GameObject gameOver;
    public float currentHealth;

    [SerializeField] Healthbar healthBar;

    public bool shieldActivated;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void OnDamageTaken(float damage)
    {
        if (shieldActivated || !GameManager.Instance.GameStarted)
            return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            GameManager.Instance.GameStarted = false;
            gameOver.SetActive(true);
            Time.timeScale = 0;
            AudioManager.Instance.StopPlaying();
            GetComponent<AudioSource>().Stop();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
}
