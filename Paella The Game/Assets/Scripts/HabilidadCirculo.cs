using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadCirculo : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject prefabCirculo;
    public float radioDelCirculo = 5f; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(ActivarCirculo());
        }
    }

    IEnumerator ActivarCirculo()
    {
        GameObject circulo = Instantiate(prefabCirculo, enemigo.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(circulo); 
        Collider[] enemigosEnCirculo = Physics.OverlapSphere(enemigo.transform.position, radioDelCirculo);

        foreach (Collider enemigoEnCirculo in enemigosEnCirculo)
        {
            if (enemigoEnCirculo.CompareTag("Vieja"))
            {
                
                Destroy(enemigoEnCirculo.gameObject);
            }
        }
    }
}