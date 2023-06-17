using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAgua : MonoBehaviour
{
    public GameObject player;
    public GameObject save;
    public GameObject tigre;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Vector3 savePosition = save.transform.position;
            player.transform.position = savePosition;
        }
        if (collision.gameObject == tigre)
        {
            tigre.transform.position = new Vector3(76.581337f, 6.99505854f, 125.693581f);
        }
    }
}