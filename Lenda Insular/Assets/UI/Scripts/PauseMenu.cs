using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuObject;
    private bool isPaused = false;


    void Start()
    {
        menuObject.SetActive(false);
    }
    void Update()
    {
        Debug.Log("hello2");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Debug.Log("hello");
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Congela o tempo do jogo
        isPaused = true;
        menuObject.SetActive(true); // Torna o objeto do menu visível
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Retorna ao tempo normal do jogo
        isPaused = false;
        menuObject.SetActive(false); // Oculta o objeto do menu
    }
}
