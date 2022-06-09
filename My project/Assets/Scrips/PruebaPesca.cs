using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPesca : MonoBehaviour
{

    public CapturaPez captura;
    public ResultadoPuntaje puntajes;
    public HiloCania hiloAnimaciones;

    int numeroRepeticiones = 0;

    int repeticionesEsperadas = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("iniciarPesca");
    }

    IEnumerator iniciarPesca()
    {
        while(numeroRepeticiones != repeticionesEsperadas)
        {
            hiloAnimaciones.animacionCorrutina(20);
            yield return new WaitForSeconds(5f);
            captura.RNGCaptura();
            yield return new WaitForSeconds(5f);
            numeroRepeticiones ++;
        }
        yield return new WaitForSeconds(5f);
        puntajes.puntajeDesplegar(captura.contadorPezNormal, captura.contadorPezNormal2, captura.contadorPezRaro, captura.contadorBota, captura.contadorAlga, captura.contadorTesoro);
    }
}
