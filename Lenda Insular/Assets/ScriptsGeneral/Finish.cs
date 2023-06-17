using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Crons cron;
    public GameObject player;
    public Crus unl;

    public void Start()
    {

    }
    private void termina()
    {
        SceneManager.LoadScene("MainMenu");
        unl.UnlockCursor();
        cron.addTime();
        cron.SaveTime();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            termina();
        }
    }
}

