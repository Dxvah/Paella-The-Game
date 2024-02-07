using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccederJuego : MonoBehaviour
{
   public void CargarEscenaDelJuego()
    {
       
        SceneManager.LoadScene("EscenaDeCarga");
    }
}
