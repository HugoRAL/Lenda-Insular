using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
   // private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    public bool shoot;
     
    // Start is called before the first frame update
    void Start()
    {
       // this.rb = GetComponent<Rigidbody>();
       shoot=false;
    }


    // Update is called once per frame
    void Update()
    {
        Grounded();
        //Jump();
        Move();
    }
    /*
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }

    }*/
    private void Grounded()
    {
        this.grounded = (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask)) ? true : false;
       // this.anim.SetBool("Jump", this.grounded);
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
