using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject pauseMenu;
    public GameObject pickItem;

    private bool pause;
    void Start()
    {

        crosshair.SetActive(false);
        pauseMenu.SetActive(false);
        pickItem.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseMenu(pause);
        }
    }

    public void CrossHair(bool show) => crosshair.SetActive(show);
    public void PauseMenu(bool show)=> pauseMenu.SetActive(show);
    public void PickItem(bool show) => pickItem.SetActive(show);
}
