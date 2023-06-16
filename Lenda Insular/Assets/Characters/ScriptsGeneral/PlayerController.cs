using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public LayerMask layerMask;

    public bool shoot;
    private Rigidbody rb; // Refer�ncia ao Rigidbody do objeto jogador

    public InGameUI Ui;
    public CameraController Camera;

    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        rb = GetComponent<Rigidbody>(); // Obt�m a refer�ncia ao Rigidbody do objeto jogador
        rb.freezeRotation = true; // Desabilita a rotacao

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseMenu();
        }
        if (Time.timeScale==1)
        {
            Move();
            Apontar();
            Camera.SetRotacao();
        }


    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();

        transform.position += movement * 0.07f;

        anim.SetFloat("Vertical", verticalAxis);
        anim.SetFloat("Horizontal", horizontalAxis);
    }

    private void Apontar()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ui.CrossHair(true);
            Camera.FPS();
        }
        else if (Input.GetMouseButtonUp(1))
        {

            Ui.CrossHair(false);
            Camera.TPS();
        }
    }

    private void PauseMenu()
    {
        Ui.PauseMenu(pause);
        Time.timeScale = (pause ? 0 : 1);
    }
}
