using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Crons cron;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void termina()
    {
        SceneManager.LoadScene("MainMenu");
        cron.addTime();
    }
    private void OnCollisionEnter(Collision collision)
    {
        termina();
    }
}
