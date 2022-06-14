using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiloCania : MonoBehaviour
{
    float velocidad = 0.08f;
    int tiempoEspera = 0;

    public void animacionCorrutina(int tiempo){
        tiempoEspera = tiempo;
        StartCoroutine("animacionHiloAbajo");
    }
 
    IEnumerator animacionHiloAbajo()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + velocidad);
            yield return new WaitForSeconds(0.1f);
        }
        for(int x = 0; x != tiempoEspera; x++)
        {
           transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - velocidad);
           yield return new WaitForSeconds(0.1f);
        }
    }
}
