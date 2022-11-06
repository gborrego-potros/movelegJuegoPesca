using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarCebo : MonoBehaviour
{
    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 10f;
    int tiempoEspera = 20;

    void Start()
    {
        if (Screen.width >= 800 && Screen.height >= 480 && Screen.width < 1024)
        {
            velocidad = 7.5f;
        }
        else if (Screen.width >= 1024 && Screen.height >= 600 && Screen.width < 1280)
        {
            velocidad = 9.5f;
        }
        else if (Screen.width >= 1280 && Screen.height >= 720 && Screen.width < 1920)
        {
            velocidad = 10f;
        }
        else if (Screen.width >= 1920 && Screen.height >= 720 && Screen.width < 2160)
        {
            velocidad = 14.5f;
        }
        else if (Screen.width >= 2160 && Screen.height >= 1080 && Screen.width < 2560)
        {
            velocidad = 13.5f;
        }
        else if (Screen.width >= 2560 && Screen.height >= 1440 && Screen.width < 2960 && Screen.height < 1700)
        {
            velocidad = 21.5f;
        }
        else if (Screen.width >= 2800 && Screen.height >= 1752)
        {
            velocidad = 24.5f;
        }
        else if (Screen.width >= 2960 && Screen.height >= 1440)
        {
            velocidad = 19.5f;
        }
        
        else
        {
            velocidad = 14.5f;
        }
    }
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
        for (int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia abajo
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidad);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //Corrutina que realiza la animacion de movimiento del cebo arriba
    IEnumerator animacionCeboArriba()
    {
        for (int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
