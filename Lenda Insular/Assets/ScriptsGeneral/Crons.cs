using UnityEngine;
using TMPro;

public class Crons : MonoBehaviour
{
    private float currentTime = 0f;
    private bool isTimerRunning = true;
    private bool endGame = false;
    public TextMeshProUGUI timerTextMeshPro;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleTimer();
        }

        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
        }

        timerTextMeshPro.text = FormatTime(currentTime);
        Debug.Log(currentTime);
    }

    private void RestartGame()
    {
        Debug.Log("Jogo reiniciado!");
        currentTime = 0f;
        isTimerRunning = true;
        endGame = false;
    }

    private void ToggleTimer()
    {
        isTimerRunning = !isTimerRunning;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}