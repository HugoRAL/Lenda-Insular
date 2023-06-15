using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cron : MonoBehaviour
{

    public Text textoCronometro; // Referência ao componente de texto para exibir o cronômetro
    private float tempo; // Tempo passado em segundos

    private bool Conta = false;

    public void CronStrat()=> Conta = true;
    public void CronReset() => tempo = 0;
    public void CronFinish() => Conta = false;

    private void Update()
    {
        if (Conta)
        {
            // Incrementa o tempo passado desde o início do jogo
            tempo += Time.deltaTime;

            // Formata o tempo em minutos e segundos
            int minutos = Mathf.FloorToInt(tempo / 60);
            int segundos = Mathf.FloorToInt(tempo % 60);

            // Atualiza o texto do cronômetro
            textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }

    }
}
