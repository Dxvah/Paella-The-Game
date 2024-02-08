using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banco : MonoBehaviour
{
    public float Vida = 50f, vidaMaxima = 50f;
    public float rango = 3.5f;
    public Image vidaBanco;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        vidaBanco.fillAmount = Vida/vidaMaxima;
        if(Vida <= 0)
        {
            Debug.Log("Perdiste");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
