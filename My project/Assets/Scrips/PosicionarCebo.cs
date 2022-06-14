using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosicionarCebo : MonoBehaviour
{
    float velocidad = 10f;
    int tiempoEspera = 0;

    public void iniciarAnimacionCorrutina(int tiempo){
        tiempoEspera = tiempo;
        StartCoroutine("animacionCeboAbajo");
    }

    IEnumerator animacionCeboAbajo()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidad);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
           transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
           yield return new WaitForSeconds(0.1f);
        }
    }
} 
