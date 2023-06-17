using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptRestart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    } 
}
