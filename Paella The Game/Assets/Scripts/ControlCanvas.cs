using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCanvas : MonoBehaviour
{
    public Canvas canvas;

    private bool isPaused = false;

    void Start()
    {
       
        canvas.enabled = false;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
       
        isPaused = !isPaused;

        if (isPaused)
        {
            
            Time.timeScale = 0f;
        }
        else
        {
            
            Time.timeScale = 1f;
        }

       
        canvas.enabled = isPaused;
    }
}

