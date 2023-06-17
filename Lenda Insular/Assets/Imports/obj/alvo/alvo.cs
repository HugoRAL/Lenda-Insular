using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alvo : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude do movimento horizontal
    public float speed; // Velocidade do movimento horizontal
    private Vector3 startPos; // Posição inicial do objeto

    public GameObject m1;
    public GameObject m2;
    public GameObject barreira;

    private void Start()
    {
        startPos = transform.position; // Armazena a posição inicial do objeto

        // Adiciona um Collider Box ao objeto
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        // Configura o tamanho do Collider Box
        boxCollider.size = new Vector3(1f, 1f, 1f);
        // Configura o centro do Collider Box
        boxCollider.center = Vector3.zero;
    }

    private void Update()
    {
        // Calcula a posição horizontal com base no tempo
        float newX = startPos.x + Mathf.Sin(Time.time * speed) * amplitude;

        // Atualiza a posição do objeto
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroi este objeto
        Destroy(gameObject);
        Destroy(m1);
        Destroy(m2);
        Destroy(barreira);
    }
}
