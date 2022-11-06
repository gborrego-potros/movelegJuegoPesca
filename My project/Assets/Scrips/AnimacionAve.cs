using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimacionAve : MonoBehaviour
{
    public GameObject ave;

    public Image sprite;

    private Animator animator;

    public bool direccion;

    //Variables para la velocidad y el tiempo de duracion de la animacion
    int velocidad = 10;
    int tiempoEspera = 40;

    public void Start()
    {
        //animator = GetComponent<Animator>();
        sprite = GameObject.Find("Cuervo").GetComponent<Image>();
        animator = GetComponent<Animator>();
        direccion = false;
    }

    public void Update(){
        //animator.SetFloat("posicionX", ave.transform.position.x); 
        animator.SetBool("direccion", direccion);
    }

    //Metodo que comienza la animacion de movimiento del hilo
    public void animacionIniciar(int speed)
    {
        velocidad = speed;
        StartCoroutine("animacionAve");
    }
    
    //Corrutina que realiza la animacion de movimiento del hilo
    IEnumerator animacionAve()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            direccion = false;
        
            //Realiza la animacion moviendo la posicion en Y del sprite del ave hacia abajo
            ave.transform.position = new Vector2(ave.transform.position.x + velocidad, ave.transform.position.y);

            //animator.SetFloat("posicionX", ave.transform.position.x);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
            direccion = true;
            
            //Realiza la animacion moviendo la posicion en Y del sprite del ave hacia arriba
            ave.transform.position = new Vector2(ave.transform.position.x - velocidad, ave.transform.position.y);

           //animator.SetFloat("posicionX", ave.transform.position.x);
           yield return new WaitForSeconds(0.1f);
        }
    }
}
