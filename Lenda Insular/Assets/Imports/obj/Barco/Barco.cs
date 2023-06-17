using UnityEngine;

public class Barco : MonoBehaviour
{
    public GameObject player;
    public GameObject ui;
    public float velocidadeMovimento = 1f;

    private bool moverParaDestino = false; 
    private bool emPosicao = false;
    private bool naoFuncionar = false;
    private Vector3 posicaoDestino;
    private float tempoInicial;
    private float duracaoMovimento = 5f;

    private void OnCollisionEnter(Collision collision)
    {if (!naoFuncionar) {
            if (collision.gameObject == player)
            {
                ui.SetActive(true);
                emPosicao = true;
                posicaoDestino = new Vector3(149.69f, 5.35f, 106.31f);
                tempoInicial = Time.time;
            }
            else
            {
                emPosicao = false;
                ui.SetActive(false);
            }
        }


    }

    private void Update()
    {
        if (emPosicao && Input.GetKeyDown(KeyCode.E))
        {
            moverParaDestino = true;
        }
        if (moverParaDestino)
        {
            float tempoDecorrido = Time.time - tempoInicial;
            float fracaoCompleta = tempoDecorrido / duracaoMovimento;

            Vector3 parentPosition = transform.position;

            // Define a posi��o do objeto player com um deslocamento vertical
            Vector3 playerPosition = new Vector3(parentPosition.x, parentPosition.y + 1, parentPosition.z);
            player.transform.position = playerPosition;

            if (transform.position == posicaoDestino)
            {
                // Chegou ao destino
                
                moverParaDestino = false;
                naoFuncionar = true;
                player.transform.position = new Vector3(160.179993f, 6.28000021f, 106.309998f);
                ui.SetActive(false);
                Destroy(gameObject);
                return;
            }

            // Interpola a posi��o atual at� a posi��o de destino
            transform.position = Vector3.Lerp(transform.position, posicaoDestino, fracaoCompleta);
        }
    }
}
