using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerController;

public class Gun : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    private float bulletSpeed = 5000;
    public GameObject jogador;
    public GameObject camera;

    [SerializeField]
    private GameObject hitText;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                DispararAMirar(transform.rotation);
            }
            else
            {
                Shoot(transform.rotation);
            }
            
           
        }
    }

    public void Shoot(Quaternion _rotacao)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, _rotacao);// Instancia o objeto bala na posição do ponto de criação da bala e com a rotação passada como parâmetro


        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.useGravity = false;

        bulletRb.AddForce(transform.right * -1 * bulletSpeed);// Adiciona força ao Rigidbody do clone da bala na direção do eixo X negativo (para trás)
        bullet.transform.Rotate(0f, -90f, 0f); // rotaciona a bala para a frente


        bullet.transform.localScale = new Vector3(1,1,1);
        // bullet.transform.LookAt(bulletPoint.transform.position); // ajusta a rotação do clone da bala

        BoxCollider boxCollider = bullet.AddComponent<BoxCollider>(); // Adiciona o BoxCollider à bala (bullet)
        Destroy(bullet, 2);// Destroi o clone da bala após 2 segundos
    }

    private void DispararAMirar(Quaternion _rotacao)
    {
        Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.useGravity = false;

            Vector3 direction = targetPosition - bullet.transform.position;
            direction.Normalize();

            bulletRb.AddForce(direction * bulletSpeed);

            bullet.transform.localScale = Vector3.one;
            bullet.transform.rotation = Quaternion.LookRotation(direction);
            BoxCollider boxCollider = bullet.AddComponent<BoxCollider>(); // Adiciona o BoxCollider à bala (bullet)

            Destroy(bullet, 2f);
        }
    }

}
