using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public static MouseControl Instance;
    private void Start()
    {
        Instance = this;
        UnClockMouse();
    }
    public void ClockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    public  void UnClockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }
}
