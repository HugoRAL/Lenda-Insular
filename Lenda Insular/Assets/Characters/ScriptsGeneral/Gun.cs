using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerController;

public class Gun : MonoBehaviour
{
    private PlayerController _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    private float bulletSpeed = 5000;
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

            Shoot(transform.rotation);
            _input.shoot = false;
        }
    }

    public void Shoot(Quaternion _rotacao)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, _rotacao);// Instancia o objeto bala na posi��o do ponto de cria��o da bala e com a rota��o passada como par�metro


        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.useGravity = false;

        bulletRb.AddForce(transform.right * -1 * bulletSpeed);// Adiciona for�a ao Rigidbody do clone da bala na dire��o do eixo X negativo (para tr�s)
        bullet.transform.Rotate(0f, -90f, 0f); // rotaciona a bala para a frente


        bullet.transform.localScale = new Vector3(1,1,1);
        // bullet.transform.LookAt(bulletPoint.transform.position); // ajusta a rota��o do clone da bala


        Destroy(bullet, 2);// Destroi o clone da bala ap�s 2 segundos
    }

}
