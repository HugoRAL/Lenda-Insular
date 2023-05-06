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
    private float bulletSpeed = 100;
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
            Shoot(jogador.transform.rotation.y);
            _input.shoot = false;
        }
    }

    public void Shoot(float x)
    {
        Debug.Log("shoot!");
        Debug.Log(jogador.transform.rotation);
        Debug.Log(transform.rotation);
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position + transform.forward * 2, Quaternion.Euler(0, jogador.transform.rotation.y, 0));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();//rigid body clone
        bulletRb.useGravity = false;
        bullet.GetComponent<Rigidbody>().AddForce(transform.right * -1 * bulletSpeed);
        bullet.transform.localScale = new Vector3(50, 50, 50);
        Debug.Log(bullet.transform.rotation);
        Destroy(bullet, 2);
    }
    
}
