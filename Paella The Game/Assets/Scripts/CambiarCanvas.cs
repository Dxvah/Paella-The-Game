using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarCanvas : MonoBehaviour
{
    public GameObject menuOpcionesCanvas;
    public GameObject creditoCanvas;

    void Start()
    {
        
        menuOpcionesCanvas.SetActive(true);
        creditoCanvas.SetActive(false);
    }

    public void CambiarACredito()
    {
        
        menuOpcionesCanvas.SetActive(false);
        creditoCanvas.SetActive(true);
    }

    public void VolverAlMenu()
    {
        
        creditoCanvas.SetActive(false);
        menuOpcionesCanvas.SetActive(true);
    }
}

