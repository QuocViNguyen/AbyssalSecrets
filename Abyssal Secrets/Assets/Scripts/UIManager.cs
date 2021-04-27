using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditPanel;
    [SerializeField] GameObject artifactUI;
    [SerializeField] GameObject winPanel;
    [SerializeField] PlayerArtifacts playerArtifacts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (artifactUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            artifactUI.SetActive(false);
            if (playerArtifacts.IsFullArtifacts())
            {
                ShowEndGame();
            }
        }
    }

    public void ShowEndGame()
    {
        GameManager.Instance.GameStarted = false;
        AudioManager.Instance.PlayGameOver();
        winPanel.SetActive(true);
    }

    public void ShowCredit()
    {
        mainMenu.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
