using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    // Referência para o jogador
    public GameObject player;
    private GameObject porta;
    public GameObject interactText;


    private bool isPlayerInRange = false;
    // Distância máxima para apanhar o item
    public float pickupRange = 30000f;
    private BoxCollider boxCollider;

    // Variável para controlar se o item foi apanhado
    private bool itemPickedUp = false;

    // Variável para controlar a chave
    private bool key = false;
    void Start()
    {
        porta = GameObject.Find("porta");
        // Adiciona um BoxCollider ao objeto
        boxCollider = gameObject.AddComponent<BoxCollider>();
        interactText.SetActive(false);
        // Define o tamanho da caixa de colisão (largura, altura, profundidade)
        boxCollider.size = new Vector3(1f, 1f, 1f);

        // Define a posição local da caixa de colisão (em relação ao objeto)
        boxCollider.center = new Vector3(0f, 0f, 0f);

        // Define se a caixa de colisão é um gatilho (não física) ou não
        boxCollider.isTrigger = false;
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Ação a ser executada quando o jogador pressionar a tecla E
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            interactText.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactText.SetActive(false);
            isPlayerInRange = false;
        }
    }
    // Método para apanhar o item
    private void PickUp()
    {
        // Lógica para apanhar o item
        Debug.Log("Item apanhado!");

        // Definir a variável de controle como verdadeira
        itemPickedUp = true;

        // Definir a variável de chave como verdadeira
        key = true;
        interactText.SetActive(false);
        isPlayerInRange = false;
        // Ocultar o objeto do item
        gameObject.SetActive(false);
        porta.gameObject.SetActive(false);

    }

}