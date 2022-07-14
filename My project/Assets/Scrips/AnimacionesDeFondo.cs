using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesDeFondo : MonoBehaviour
{

    public AnimacionAve animacionAve;
    public AnimacionPeces animacionPeces;
    
    int x = 0;

    int Espera = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("iniciarPesca");
    }

    //Corrutina que inicia todo el proceso de pesca.
    IEnumerator iniciarPesca()
    {
        while(x != Espera)
        {
            animacionPeces.animacionIniciar(40);
            animacionAve.animacionIniciar(40);
            yield return new WaitForSeconds(8f);
        }
    }
}
