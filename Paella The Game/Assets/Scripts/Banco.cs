using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banco : MonoBehaviour
{
    public float Vida = 50f, vidaMaxima = 50f;
    public float rango = 3.5f;
    public Image vidaBanco;
    public Canvas ui;
    public Canvas canvasfinal;

    void Start()
    {
        
    }

    
    void Update()
    {
        vidaBanco.fillAmount = Vida/vidaMaxima;
        if(Vida <= 0)
        {
            canvasfinal.gameObject.SetActive(true);
            ui.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
