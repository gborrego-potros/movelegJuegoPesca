using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiloCania : MonoBehaviour
{
    //Variables para la velocidad y el tiempo de duracion de la animacion
    float velocidad = 0.08f;
    int tiempoEspera = 20;

    void Start()
    {
        if (Screen.width >= 800 && Screen.height >= 480 && Screen.width < 1280)
        {
            velocidad = 0.145f;

        }
        else if (Screen.width >= 1024 && Screen.height >= 600 && Screen.width < 1280)
        {
            velocidad = 0.115f;
        }
        else if (Screen.width >= 1280 && Screen.height >= 720 && Screen.width < 1920)
        {
            velocidad = 0.125f;
        }
        else if (Screen.width >= 1920 && Screen.height >= 720 && Screen.width < 2160)
        {
            velocidad = 0.125f;
        }
        else if (Screen.width >= 2160 && Screen.height >= 1080 && Screen.width < 2560)
        {
            velocidad = 0.105f;
        }
        else if (Screen.width >= 2560 && Screen.height >= 1440 && Screen.width < 2960 && Screen.height < 1700)
        {
            velocidad = 0.13f;
        }
        else if (Screen.width >= 2800 && Screen.height >= 1752)
        {
            velocidad = 0.142f;
        }
        else if (Screen.width >= 2960 && Screen.height >= 1440)
        {
            velocidad = 0.105f;
        }
        else
        {
            velocidad = 0.135f;
        }
    }
    //Metodo que comienza la animacion de movimiento del hilo hacia abajo
    public void animacionCorrutinaAbajo()
    {
        StartCoroutine("animacionHiloAbajo");
    }

    //Metodo que comienza la animacion de movimiento del hilo hacia arriba
    public void animacionCorrutinaArriba()
    {
        StartCoroutine("animacionHiloArriba");
    }

    //Corrutina que realiza la animacion de movimiento del hilo hacia abajo
    IEnumerator animacionHiloAbajo()
    {
        for (int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del hilo hacia abajo
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + velocidad, transform.localScale.z);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //Corrutina que realiza la animacion de movimiento del hilo hacia arriba
    IEnumerator animacionHiloArriba()
    {
        for (int x = 0; x != tiempoEspera; x++)
        {
            //Realiza la animacion moviendo la posicion en Y del sprite del cebo hacia arriba
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - velocidad, transform.localScale.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
