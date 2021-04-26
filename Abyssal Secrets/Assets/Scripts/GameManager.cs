using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerHealth playerHealth;

    private enum GameState
    {
        Waiting,
        Playing,
        Over
    }
    private GameState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Playing && playerHealth.IsDead())
        {
            uiManager.ShowGameOver();
        }
    }
}
