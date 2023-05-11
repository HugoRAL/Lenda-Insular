using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Objeto jogador
    public GameObject crosshair; // Objeto crosshair

    public Vector3 defaultPosition; // Posição padrão da câmera
    public Vector3 zoomedPosition; // Posição da câmera quando o jogador clica no botão direito do mouse

    public float smoothTime = 0.5f; // Tempo de transição suave da câmera

    private Vector3 smoothVelocity; // Velocidade suave da transição da câmera

    private bool isZoomed = false; // Flag para indicar se a câmera está no modo de zoom

    private float currentRotationX = 0f; // Rotação vertical atual da câmera

    private Vector3 defaultCameraPosition; // Posição padrão da câmera antes do zoom

    void Start()
    {
        transform.position = defaultPosition; // Define a posição inicial da câmera como a posição padrão
        smoothVelocity = Vector3.zero; // Define a velocidade inicial da transição da câmera como zero
        crosshair.SetActive(false); // Desativa o objeto crosshair no início do jogo
        defaultCameraPosition = transform.position; // Salva a posição padrão da câmera
    }

    void LateUpdate()
    {
        // Se o botão direito do mouse for pressionado, a câmera muda para a posição de zoom
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = true;
            crosshair.SetActive(true); // Ativa o objeto crosshair
            transform.position = zoomedPosition; // Define a posição da câmera para a posição de zoom
        }

        // Se o botão direito do mouse não estiver pressionado, a câmera volta para a posição padrão
        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
            crosshair.SetActive(false); // Desativa o objeto crosshair
            transform.position = defaultCameraPosition; // Define a posição da câmera para a posição padrão
        }

        // Transição suave da câmera
        if (!isZoomed) // Apenas suaviza a transição se a câmera não estiver no modo de zoom
        {
            Vector3 targetPosition = defaultPosition;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothTime);
        }

        // Rotação do objeto jogador com o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up, mouseX);

        // Rotação vertical da câmera com o movimento do mouse
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotationX += mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, -15f, 15f);
        transform.localEulerAngles = new Vector3(-currentRotationX, transform.localEulerAngles.y, 0f);

        // Define a posição da câmera com base na posição do jogador
        Vector3 cameraPosition = player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f;

        // Atualiza a posição da câmera mantendo todos os eixos do jogador
        transform.position = cameraPosition;
    }
}