using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Objeto jogador
    public GameObject crosshair; // Objeto crosshair

    private float currentRotationX = 0f; // Rotação vertical atual da câmera



    void Start()
    {

        crosshair.SetActive(false); // Desativa o objeto crosshair no início do jogo
        SetPosicao(player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f);
    }

    void LateUpdate()
    {



        SetRotacao();
        Apontar();
    }

    private void Apontar()
    {
        if (Input.GetMouseButtonDown(1))
        {
            crosshair.SetActive(true);
            Vector3 newPosition = (player.transform.position - player.transform.forward * 1.5f + Vector3.up * 2.5f+ player.transform.right * 1.5f);

            SetPosicao(newPosition);
        }
        else if (Input.GetMouseButtonUp(1))
        {

            crosshair.SetActive(false);
            SetPosicao(player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f);
        }
    }

    private void SetRotacao()
    {
        // Rotação do objeto jogador com o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up, mouseX);

        // Rotação vertical da câmera com o movimento do mouse
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotationX += mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, -15f, 15f);
        transform.localEulerAngles = new Vector3(-currentRotationX, transform.localEulerAngles.y, 0f);
    }

    private void SetPosicao(Vector3 cameraPosition)=> transform.position = cameraPosition;

}