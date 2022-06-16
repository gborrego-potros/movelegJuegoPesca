using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarCebo : MonoBehaviour
{
    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 10f;
    int tiempoEspera = 0;
    
    //Metodo que comienza la animacion de movimiento del cebo
    public void iniciarAnimacionCorrutina(int tiempo){
        tiempoEspera = tiempo;
        StartCoroutine("animacionCeboAbajo");
    }

    //Corrutina que realiza la animacion de movimiento del cebo
    IEnumerator animacionCeboAbajo()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia abajo
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidad);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
           transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
           yield return new WaitForSeconds(0.1f);
        }
    }
} 
