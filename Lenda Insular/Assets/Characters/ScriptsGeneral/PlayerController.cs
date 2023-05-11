using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public LayerMask layerMask;

    public bool shoot;
    private Rigidbody rb; // Referência ao Rigidbody do objeto jogador



    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        rb = GetComponent<Rigidbody>(); // Obtém a referência ao Rigidbody do objeto jogador
        rb.freezeRotation = true; // Desabilita a rotação


    }

    void Update()
    {
        Move();

    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();

        transform.position += movement * 0.04f;

        anim.SetFloat("Vertical", verticalAxis);
        anim.SetFloat("Horizontal", horizontalAxis);
    }

   
}
