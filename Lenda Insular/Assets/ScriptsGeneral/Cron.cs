using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cron : MonoBehaviour
{
    private float currentTime = 0f;
    private bool isTimerRunning = true; // Indica se o timer está em execução
    private bool endGame = false; // Indica se o tempo acabou
    public TextMeshProUGUI timerTextMeshPro; // Variável para armazenar o TextMeshPro

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
        }

        // Atualiza o texto do timer
        timerTextMeshPro.text = FormatTime(currentTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("MainMenu");

        }

        // Verifica se o tempo acabou
        if (endGame)
        {
            // Realize as ações finais ou termine o jogo aqui
            // Exemplo: chame a função EndGame()
            EndGame();
        }
    }

    private void EndGame()
    {
        // Lógica para o fim do jogo
        Debug.Log("Tempo acabou! Fim do jogo!");

        // Resetar o tempo
        currentTime = 0f;
        isTimerRunning = true;
        endGame = false;
    }

    private void RestartGame()
    {
        // Lógica para reiniciar o jogo
        Debug.Log("Jogo reiniciado!");

        // Resetar o tempo
        currentTime = 0f;
        isTimerRunning = true;
        endGame = false;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ReturnToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
                // Pausar ou retomar o tempo quando "Esc" é pressionado durante o jogo
                isTimerRunning = !isTimerRunning;
        }
    }
}


