using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPeces : MonoBehaviour
{
    public GameObject pez1;

    public GameObject pez2;

    //Variables para la velocidad y el tiempo de duracion de la animacion
    int velocidad = 10;
    int tiempoEspera = 40;

    //Metodo que comienza la animacion de movimiento del hilo
    public void animacionIniciar(int speed)
    {
        velocidad = speed;
        StartCoroutine("animacionPez");
    }
    
    //Corrutina que realiza la animacion de movimiento del hilo
    IEnumerator animacionPez()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en X del sprite del pez1
            pez1.transform.position = new Vector2(pez1.transform.position.x - velocidad, pez1.transform.position.y);
            pez2.transform.position = new Vector2(pez2.transform.position.x + velocidad, pez2.transform.position.y);
            yield return new WaitForSeconds(0.1f);
        }
        pez1.transform.Rotate(0, 180, 0);
        pez2.transform.Rotate(0, 180, 0);
        for(int x = 0; x != tiempoEspera; x++)
        {
           //Realiza la animacion moviendo la posicion en X del sprite del pez1
           pez1.transform.position = new Vector2(pez1.transform.position.x + velocidad, pez1.transform.position.y);
           pez2.transform.position = new Vector2(pez2.transform.position.x - velocidad, pez2.transform.position.y);
           yield return new WaitForSeconds(0.1f);
        }
        pez1.transform.Rotate(0, 180, 0);
        pez2.transform.Rotate(0, 180, 0);
    }
}
