using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {

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
}
