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
    {
        if (!naoFuncionar)
        {
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
            player.transform.position = new Vector3(161.003479f, 4.99908447f, 112.270126f); 
            moverParaDestino = false;
            ui.SetActive(false);
        }
    }
}

