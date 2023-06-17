using UnityEngine;

public class Cursor : MonoBehaviour
{
    private bool cursorVisible = false;

    void Start()
    {
        HideCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorVisible = !cursorVisible;

            if (cursorVisible)
            {
                ShowCursor();
            }
            else
            {
                HideCursor();
            }
        }
    }

    private void ShowCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    private void HideCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
