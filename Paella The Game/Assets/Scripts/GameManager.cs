using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TMP_Text monedastext;
    public int MonedasTotales { get { return Monedas; } }

    //-------------------------------------
    public int Monedas;
    public int EnemigosDerrotados;

    //-------------------------------------
    public float tiempo;
    public float Oleadas = 0;
    public bool EnOleada = false;

//-------------------------------------------------------------------------------------------------------------------------
    public void Start()
    {
        Monedas = 0;
        EnemigosDerrotados = 0;
    }

//-------------------------------------------------------------------------------------------------------------------------
    public void Update()
    {
        monedastext.text = MonedasTotales.ToString();
        tiempo += Time.deltaTime;
        ControlDeOleadas();
    }

//-------------------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un Game Manager");
        }
    }

//-------------------------------------------------------------------------------------------------------------------------
    public void ControlDeOleadas()
    {
        if (Oleadas == 0 && EnOleada == false)
        {
            EnOleada = true;
            Oleadas = 1f;
        }
        else if (Oleadas == 1 && EnOleada == true && EnemigosDerrotados == 7)
        {
            EnOleada = false;
            Oleadas = 2;
        }
        if (Oleadas == 2 && EnOleada == false)
        {
            EnOleada = true;
        }
        else if (Oleadas == 2 && EnOleada == true && EnemigosDerrotados == 21)
        {
            EnOleada = false;
            Oleadas = 3;
        }
        if (Oleadas == 3 && EnOleada == false)
        {
            EnOleada = true;
        }
        else if (Oleadas == 3 && EnOleada == true && EnemigosDerrotados == 49)
        {
            EnOleada = false;
            Debug.Log("El banco se ha salvado");
        }
    }

//-------------------------------------------------------------------------------------------------------------------------
    public void MonedasPorEnemigo(int MonedasObtenidos)
    {
        Monedas += MonedasObtenidos;
        EnemigosDerrotados += 1;
        Debug.Log("Monedas y Enemigos = " + Monedas + "  " + EnemigosDerrotados);
    }
}
