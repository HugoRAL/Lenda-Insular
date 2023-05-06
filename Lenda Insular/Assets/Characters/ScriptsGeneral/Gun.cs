using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Gun : MonoBehaviour
{
    private PlayerController _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    private float bulletSpeed = 600;
    public GameObject jogador;
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            _input.shoot = false;
        }
    }

    public void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();//rigid body clone
        bulletRb.useGravity = false;
        bullet.GetComponent<Rigidbody>().AddForce(transform.right * -1 * bulletSpeed);
        Destroy(bullet, 2);
    }
    
}
