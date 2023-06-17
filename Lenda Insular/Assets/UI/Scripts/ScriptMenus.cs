using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptMenus : MonoBehaviour
{
    [SerializeField] public SliderSensibilidade Sens;
    public void Play() => SceneManager.LoadScene("MainLevel");
    public void BntQuit()=> Application.Quit();

}

