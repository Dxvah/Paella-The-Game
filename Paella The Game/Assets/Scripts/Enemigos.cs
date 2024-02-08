
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{   
    public GameManager gameManager;
    private Banco bancoGO;
    public Animator anim;
    public string Banco = "Banco";
    public int Monedas, dañoRecibido;
    public float minVelocidad, maxVelocidad, velocidad;
    public int vidas = 4, daño = 1, cooldownAtaque = 5;
    public bool atacando = false;
    public Animator viejaAnim;


    //-------------------------------------------------------------------------------------------------------------------------
    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();                             //--- Buscar el GameManager
 
        velocidad = Random.Range(minVelocidad, maxVelocidad) * Time.deltaTime;     //--- Velocidad Enemigo.
    }

//-------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        GameObject banco = GameObject.FindGameObjectWithTag(Banco);
        float DistanciaAlBanco = Vector3.Distance(transform.position, banco.transform.position);
        bancoGO = banco.GetComponent<Banco>();
        transform.LookAt(bancoGO.transform);
        GameObject player = GameObject.FindWithTag("Player");
        Animator playerAnimator = player.GetComponent<Animator>();


        if (atacando == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, banco.transform.position, velocidad);      //---Persecución del Banco.
            viejaAnim.SetTrigger("correr");
            viejaAnim.ResetTrigger("pegando");

            if (DistanciaAlBanco <= bancoGO.rango)
            {
                StartCoroutine(AtacandoElBanco());
            }
        }

        if(DistanciaAlBanco > bancoGO.rango)
        {

            atacando = false;

        }
    }

//-------------------------------------------------------------------------------------------------------------------------
   private IEnumerator AtacandoElBanco()                                            //---Atacar el Banco
{   

    atacando = true;
    for(int i = 0; i < 50; i++)
    {
            viejaAnim.SetTrigger("pegando");
            viejaAnim.ResetTrigger("correr");
            bancoGO.Vida -= daño;
        i++;
        yield return new WaitForSeconds(cooldownAtaque);
    }
}

//-------------------------------------------------------------------------------------------------------------------------
   public void OnCollisionStay(Collision collision)
   {
        GameObject player = GameObject.FindWithTag("Player");
        Animator playerAnimator = player.GetComponent<Animator>();
        if (collision.gameObject.tag == "Player" && playerAnimator && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("lucha"))                                         //---Recibir Daño
        {
            Debug.Log("Golpe");
            vidas -= dañoRecibido;
        }

        if (vidas < 1)
        {
            gameManager.MonedasPorEnemigo(Monedas);

            Destroy(gameObject);
        }
   }
}
