using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarCebo : MonoBehaviour
{
    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 10f;
    int tiempoEspera = 20;
    
    //Metodo que comienza la animacion de movimiento del cebo abajo
    public void iniciarAnimacionCorrutinaAbajo()
    {
        StartCoroutine("animacionCeboAbajo");
    }

    //Metodo que comienza la animacion de movimiento del cebo
    public void iniciarAnimacionCorrutinaArriba()
    {
        StartCoroutine("animacionCeboArriba");
    }

    //Corrutina que realiza la animacion de movimiento del cebo abajo
    IEnumerator animacionCeboAbajo()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia abajo
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidad);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //Corrutina que realiza la animacion de movimiento del cebo arriba
    IEnumerator animacionCeboArriba()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
           //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
           transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
           yield return new WaitForSeconds(0.1f);
        }
    }
} 
