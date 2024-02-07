using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cargando : MonoBehaviour
{
    public Slider barraDeProgreso;

    void Start()
    {
       
        StartCoroutine(CargarEscenaAsincrona("SampleScene"));
    }

    IEnumerator CargarEscenaAsincrona(string nombreDeLaEscena)
    {
        AsyncOperation operacionDeCarga = SceneManager.LoadSceneAsync(nombreDeLaEscena);

        
        operacionDeCarga.allowSceneActivation = false;

        while (!operacionDeCarga.isDone)
        {
            
            float progreso = Mathf.Clamp01(operacionDeCarga.progress / 0.9f); 
            barraDeProgreso.value = progreso;

            
            yield return null;

            
            if (progreso == 1.0f)
            {
                operacionDeCarga.allowSceneActivation = true;
            }
        }   
    }
}
