using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPesca : MonoBehaviour
{

    public CapturaPez captura;
    public ResultadoPuntaje puntajes;

    int numeroRepeticiones = 0;

    int repeticionesEsperadas = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("a");
    }

    IEnumerator a()
    {
        while(numeroRepeticiones != repeticionesEsperadas)
        {
            yield return new WaitForSeconds(5f);
            captura.RNGCaptura();
            numeroRepeticiones ++;
        }
        yield return new WaitForSeconds(5f);
        puntajes.puntajeDesplegar(captura.contadorPezNormal, captura.contadorPezNormal2, captura.contadorPezRaro, captura.contadorBota, captura.contadorAlga, captura.contadorTesoro);
    }
}
