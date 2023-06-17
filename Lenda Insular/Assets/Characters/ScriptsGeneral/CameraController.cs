using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Objeto jogador
    private float currentRotationX = 0f; // Rota��o vertical atual da c�mera



    void Start()
    {
        SetPosicao(player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f);

    }
    
    public void FPS()
    {
        Vector3 newPosition = (player.transform.position - player.transform.forward * 1.5f + Vector3.up * 2.5f + player.transform.right * 1.5f);
        SetPosicao(newPosition);
    }
    public void TPS()=>SetPosicao(player.transform.position - player.transform.forward * 3 + Vector3.up * 2.5f);
  


    public void SetRotacao()
    {    
    float sens = PlayerPrefs.GetFloat("Sensibilidade");

    // Rotação do objeto jogador com o movimento do mouse
    float mouseX = Input.GetAxis("Mouse X") * sens;
    player.transform.Rotate(Vector3.up, mouseX);

    // Rotação vertical da câmera com o movimento do mouse
    float mouseY = Input.GetAxis("Mouse Y") * sens;
    currentRotationX += mouseY;
    currentRotationX = Mathf.Clamp(currentRotationX, -15f, 15f);
    transform.localEulerAngles = new Vector3(-currentRotationX, transform.localEulerAngles.y, 0f);
    }

    private void SetPosicao(Vector3 cameraPosition)=> transform.position = cameraPosition;

}