using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionAve : MonoBehaviour
{
    public GameObject ave;

    private Animator animator;

    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 0.5f;
    int tiempoEspera = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Metodo que comienza la animacion de movimiento del hilo
    public void animacionIniciar(int tiempo)
    {
        tiempoEspera = tiempo;
        StartCoroutine("animacionAve");
    }
    
    //Corrutina que realiza la animacion de movimiento del hilo
    IEnumerator animacionAve()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia abajo
            ave.transform.position = new Vector2(ave.transform.position.x + velocidad, ave.transform.position.y);
            animator.SetFloat("posicionX", ave.transform.position.x);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
           ave.transform.position = new Vector2(ave.transform.position.x - velocidad, ave.transform.position.y);
           animator.SetFloat("posicionX", ave.transform.position.x);
           yield return new WaitForSeconds(0.1f);
        }
    }
}
