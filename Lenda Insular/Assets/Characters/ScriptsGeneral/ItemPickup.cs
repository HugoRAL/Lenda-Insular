using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Referência para o jogador
    public GameObject player;

    // Distância máxima para apanhar o item
    public float pickupRange = 3f;

    // Variável para controlar se o item foi apanhado
    private bool itemPickedUp = false;

    // Variável para controlar a chave
    private bool key = false;

    // Método para apanhar o item
    private void PickUp()
    {
        // Lógica para apanhar o item
        Debug.Log("Item apanhado!");

        // Definir a variável de controle como verdadeira
        itemPickedUp = true;

        // Definir a variável de chave como verdadeira
        key = true;

        // Ocultar o objeto do item
        gameObject.SetActive(false);
    }

    // Verificar colisões
    private void OnTriggerStay(Collider other)
    {
        // Verificar se a colisão é com o jogador
        if (other.gameObject == player)
        {
            // Verificar se a tecla "E" foi pressionada
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Verificar se o item já foi apanhado
                if (!itemPickedUp)
                {
                    // Calcular a distância entre o jogador e o item
                    float distance = Vector3.Distance(transform.position, player.transform.position);

                    // Verificar se o jogador está dentro da distância de apanhar o item
                    if (distance <= pickupRange)
                    {
                        // Chamar o método para apanhar o item
                        PickUp();
                    }
                }
            }
        }
    }
}
