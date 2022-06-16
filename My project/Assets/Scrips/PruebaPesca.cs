using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPesca : MonoBehaviour
{

    public CapturaPez captura;
    public ResultadoPuntaje puntajes;
    public HiloCania hiloAnimaciones;
    public PosicionarCebo ceboAnimacion;
    
    int numeroRepeticiones = 0;

    int repeticionesEsperadas = 10;

    int numeroRNG;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("iniciarPesca");
    }

    //Corrutina que inicia todo el proceso de pesca.
    IEnumerator iniciarPesca()
    {
        while(numeroRepeticiones != repeticionesEsperadas)
        {
            numeroRNG = captura.RNGCaptura();
            hiloAnimaciones.animacionCorrutina(20);
            ceboAnimacion.iniciarAnimacionCorrutina(20);
            captura.iniciarAnimacion(numeroRNG, 20);
            yield return new WaitForSeconds(5f);
            captura.DesplegarCaptura(numeroRNG);
            yield return new WaitForSeconds(5f);
            numeroRepeticiones ++;
        }
        yield return new WaitForSeconds(5f);
        puntajes.puntajeDesplegar(captura.contadorPezNormal, captura.contadorPezNormal2, captura.contadorPezRaro, captura.contadorBota, captura.contadorAlga, captura.contadorTesoro);
    }
}
