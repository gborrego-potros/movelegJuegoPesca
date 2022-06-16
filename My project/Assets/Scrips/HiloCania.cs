using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiloCania : MonoBehaviour
{
    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 0.08f;
    int tiempoEspera = 0;

    //Metodo que comienza la animacion de movimiento del hilo
    public void animacionCorrutina(int tiempo)
    {
        tiempoEspera = tiempo;
        StartCoroutine("animacionHiloAbajo");
    }
    
    //Corrutina que realiza la animacion de movimiento del hilo
    IEnumerator animacionHiloAbajo()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del hilo hacia abajo
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + velocidad);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
           //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
           transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - velocidad);
           yield return new WaitForSeconds(0.1f);
        }
    }
}
