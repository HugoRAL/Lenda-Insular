using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chave : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude do movimento vertical
    public float speed = 1f; // Velocidade do movimento vertical
    private Vector3 startPos; // Posição inicial do objeto

    private void Start()
    {
        startPos = transform.position; // Armazena a posição inicial do objeto
    }

    private void Update()
    {
        // Calcula a posição vertical com base no tempo
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Atualiza a posição do objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
