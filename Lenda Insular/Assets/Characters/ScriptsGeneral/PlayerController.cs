using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public LayerMask layerMask;
    public bool shoot;
    public Rigidbody rb; // Refer�ncia ao Rigidbody do objeto jogador

    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        rb = GetComponent<Rigidbody>(); // Obt�m a refer�ncia ao Rigidbody do objeto jogador
        rb.freezeRotation = true; // Desabilita a rota��o
    }


    void Update()
    {
        Move();   
    }


    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.04f;

        this.anim.SetFloat("Vertical", verticalAxis);
        this.anim.SetFloat("Horizontal", horizontalAxis);
    }

}
