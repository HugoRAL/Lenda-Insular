using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hit : MonoBehaviour
{
    public GameObject TxtHit;
    // Start is called before the first frame update
    void Start()
    {
        TxtHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        TxtHit.SetActive(true);
    }
}
