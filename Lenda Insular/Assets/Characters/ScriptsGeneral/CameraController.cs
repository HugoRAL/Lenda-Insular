using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Objeto jogador
    public GameObject crosshair; // Objeto crosshair

    public Vector3 defaultPosition; // Posi��o padr�o da c�mera
    public Vector3 zoomedPosition; // Posi��o da c�mera quando o jogador clica no bot�o direito do mouse

    public float smoothTime = 0.5f; // Tempo de transi��o suave da c�mera

    private Vector3 smoothVelocity; // Velocidade suave da transi��o da c�mera

    private bool isZoomed = false; // Flag para indicar se a c�mera est� no modo de zoom

    private float currentRotationX = 0f; // Rota��o vertical atual da c�mera

    private Vector3 defaultCameraPosition; // Posi��o padr�o da c�mera antes do zoom

    void Start()
    {
        transform.position = defaultPosition; // Define a posi��o inicial da c�mera como a posi��o padr�o
        smoothVelocity = Vector3.zero; // Define a velocidade inicial da transi��o da c�mera como zero
        crosshair.SetActive(false); // Desativa o objeto crosshair no in�cio do jogo
        defaultCameraPosition = transform.position; // Salva a posi��o padr�o da c�mera
    }

    void LateUpdate()
    {
        // Se o bot�o direito do mouse for pressionado, a c�mera muda para a posi��o de zoom
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = true;
            crosshair.SetActive(true); // Ativa o objeto crosshair
            transform.position = zoomedPosition; // Define a posi��o da c�mera para a posi��o de zoom
        }

        // Se o bot�o direito do mouse n�o estiver pressionado, a c�mera volta para a posi��o padr�o
        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
            crosshair.SetActive(false); // Desativa o objeto crosshair
            transform.position = defaultCameraPosition; // Define a posi��o da c�mera para a posi��o padr�o
        }

        // Transi��o suave da c�mera
        if (!isZoomed) // Apenas suaviza a transi��o se a c�mera n�o estiver no modo de zoom
        {
            Vector3 targetPosition = defaultPosition;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothTime);
        }

        // Rota��o do objeto jogador com o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up, mouseX);

        // Rota��o vertical da c�mera com o movimento do mouse
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotationX += mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, -15f, 15f);
        transform.localEulerAngles = new Vector3(-currentRotationX, transform.localEulerAngles.y, 0f);

        // Define a posi��o da c�mera com base na posi��o do jogador
        Vector3 cameraPosition = player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f;

        // Atualiza a posi��o da c�mera mantendo todos os eixos do jogador
        transform.position = cameraPosition;
    }
}