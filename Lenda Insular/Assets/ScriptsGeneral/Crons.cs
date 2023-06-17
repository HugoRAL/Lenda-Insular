using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Crons : MonoBehaviour
{
    private float currentTime = 0f;
    private bool isTimerRunning = true;
    private bool endGame = false;
    public TextMeshProUGUI timerTextMeshPro;
    public List<float>  times = new List<float>();

    private void Start()
    {
        times = GetTime();


    }
    public void addTime()=> times.Add(currentTime);
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

        if (timerTextMeshPro != null) timerTextMeshPro.text = FormatTime(currentTime);
       
    }
    public void SaveTime()
    {
        // Converter a lista de floats em uma string separada por vírgula
        string timeString = string.Join(",", times.ConvertAll(x => x.ToString()).ToArray());

        // Salvar a string no PlayerPrefs
        PlayerPrefs.SetString("times", timeString);

        // Salvar os dados do PlayerPrefs
        PlayerPrefs.Save();
    }
    public List<float> GetTime()
    {
        // Recuperar a string do PlayerPrefs
        string timeString = PlayerPrefs.GetString("times");

        // Se a string não estiver vazia
        if (!string.IsNullOrEmpty(timeString))
        {
            // Separar a string nos valores individuais
            string[] timeValues = timeString.Split(',');

            // Converter os valores em floats e adicioná-los à lista
            for (int i = 0; i < timeValues.Length; i++)
            {
                float time;
                if (float.TryParse(timeValues[i], out time))
                {
                    times.Add(time);
                }
            }
        }

        // Retornar a lista de floats
        return times;
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