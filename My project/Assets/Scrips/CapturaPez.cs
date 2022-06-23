using System.Collections;
using System.Collections.Generic;
using static System.Random;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CapturaPez : MonoBehaviour
{
    //Sprites de los items
    [SerializeField] private GameObject ImagenPezNormal;
    [SerializeField] private GameObject ImagenPezNormal2;
    [SerializeField] private GameObject ImagenPezRaro;
    [SerializeField] private GameObject ImagenBota;
    [SerializeField] private GameObject ImagenAlga;
    [SerializeField] private GameObject ImagenTesoro;
    [SerializeField] private GameObject PanelCaptura;

    //Textos del puntaje de capturas
    [SerializeField] private Text puntajeTotal;
    [SerializeField] private Text puntajePezNormal;
    [SerializeField] private Text puntajePezNormal2;
    [SerializeField] private Text puntajePezRaro;
    [SerializeField] private Text puntajeBota;
    [SerializeField] private Text puntajeAlga;
    [SerializeField] private Text puntajeTesoro;
    
    //Sprites de los items para animaciones
    [SerializeField] private GameObject SpritePezNormal;
    [SerializeField] private GameObject SpritePezNormal2;
    [SerializeField] private GameObject SpritePezRaro;
    [SerializeField] private GameObject SpriteBota;
    [SerializeField] private GameObject SpriteAlga;
    [SerializeField] private GameObject SpriteTesoro;

    //Sonido de captura
    public GameObject SonidoCaptura;

    //Contadores de capturas
    public int contadorPezNormal = 0;
    public int contadorPezNormal2 = 0;
    public int contadorPezRaro = 0;
    public int contadorBota = 0;
    public int contadorAlga = 0;
    public int contadorTesoro = 0;
    public int contadorTotal = 0;

    //Porcentaje minimo y maximo de captura del pez normal
    public int porcentajePezNormalMin = 1;
    public int porcentajePezNormalMax = 20;

    //Porcentaje minimo y maximo de captura del pez normal2
    public int porcentajePezNormal2Min = 21;
    public int porcentajePezNormal2Max = 40;

    //Porcentaje minimo y maximo de captura del pez raro
    public int porcentajePezRaroMin = 41;
    public int porcentajePezRaroMax = 50;

    //Porcentaje minimo y maximo de captura del alga
    public int porcentajeAlgaMin = 51;
    public int porcentajeAlgaMax = 70;
    
    //Porcentaje minimo y maximo de captura de la bota
    public int porcentajeBotaMin = 71;
    public int porcentajeBotaMax = 90;

    //Porcentaje minimo y maximo de captura del tesoro
    public int porcentajeTesoroMin = 91;
    public int porcentajeTesoroMax = 100;

    //Variables para la animacion
    float velocidad = 10f;
    int tiempoEspera = 0;
    int pesca;
    
    //Posicion original en Y de los sprites de captura
    float posicionPezNormalY;
    float posicionPezNormal2Y;
    float posicionPezRaroY;
    float posicionBotaY;
    float posicionAlgaY;
    float posicionTesoroY;



    //Metodo que activa la corrutina la cual realiza la animacion de captura
    public void iniciarAnimacion(int pescaRNG, int tiempo)
    {
        tiempoEspera = tiempo;
        pesca = pescaRNG;
        posicionPezNormalY = SpritePezNormal.transform.position.y;
        posicionPezNormal2Y = SpritePezNormal2.transform.position.y;
        posicionPezRaroY = SpritePezRaro.transform.position.y;
        posicionBotaY = SpriteBota.transform.position.y;
        posicionAlgaY = SpriteAlga.transform.position.y;
        posicionTesoroY = SpriteTesoro.transform.position.y;
        StartCoroutine("animacionCapturar");
    }

    //Corrutina para la animacion de captura
    IEnumerator animacionCapturar()
    {
        for(int x = 0; x != tiempoEspera; x++)
        {
            if(pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpritePezNormal.SetActive(false);
                    //Realiza la animacion
                    SpritePezNormal.transform.position = new Vector2(SpritePezNormal.transform.position.x, posicionPezNormalY);
                    yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpritePezNormal2.SetActive(false);
                    //Realiza la animacion
                    SpritePezNormal2.transform.position = new Vector2(SpritePezNormal2.transform.position.x, posicionPezNormal2Y);
                    yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpritePezRaro.SetActive(false);
                    //Realiza la animacion
                    SpritePezRaro.transform.position = new Vector2(SpritePezRaro.transform.position.x, posicionPezRaroY);
                    yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpriteAlga.SetActive(false);
                    //Realiza la animacion
                    SpriteAlga.transform.position = new Vector2(SpriteAlga.transform.position.x, posicionAlgaY);
                    yield return new WaitForSeconds(0.1f);

            } else if(pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpriteBota.SetActive(false);
                    //Realiza la animacion
                    SpriteBota.transform.position = new Vector2(SpriteBota.transform.position.x, posicionBotaY);
                    yield return new WaitForSeconds(0.1f);

            } else if(pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax)
            {
                    //Desactiva el sprite de la captura pertinente para la animacion
                    SpriteTesoro.SetActive(false);
                    //Realiza la animacion
                    SpriteTesoro.transform.position = new Vector2(SpriteTesoro.transform.position.x, posicionTesoroY);
                    yield return new WaitForSeconds(0.1f);

            }
        }

        for(int x = 0; x != tiempoEspera; x++)
        {
            if(pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpritePezNormal.SetActive(true);
                    //Llama a la animacion
                    SpritePezNormal.transform.position = new Vector2(SpritePezNormal.transform.position.x, SpritePezNormal.transform.position.y + velocidad);
                    yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpritePezNormal2.SetActive(true);
                    //Llama a la animacion
                    SpritePezNormal2.transform.position = new Vector2(SpritePezNormal2.transform.position.x, SpritePezNormal2.transform.position.y + velocidad);
                    yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpritePezRaro.SetActive(true);
                    //Llama a la animacion
                    SpritePezRaro.transform.position = new Vector2(SpritePezRaro.transform.position.x, SpritePezRaro.transform.position.y + velocidad);
           yield return new WaitForSeconds(0.1f);

            }else if(pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpriteAlga.SetActive(true);
                    //Llama a la animacion
                    SpriteAlga.transform.position = new Vector2(SpriteAlga.transform.position.x, SpriteAlga.transform.position.y + velocidad);
           yield return new WaitForSeconds(0.1f);

            } else if(pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpriteBota.SetActive(true);
                    //Llama a la animacion
                    SpriteBota.transform.position = new Vector2(SpriteBota.transform.position.x, SpriteBota.transform.position.y + velocidad);
                    yield return new WaitForSeconds(0.1f);

            } else if(pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax)
            {
                    //Activa el sprite de la captura pertinente para la animacion
                    SpriteTesoro.SetActive(true);
                    //Llama a la animacion
                    SpriteTesoro.transform.position = new Vector2(SpriteTesoro.transform.position.x, SpriteTesoro.transform.position.y + velocidad);
                    yield return new WaitForSeconds(0.1f);

            }
        }
        //Restaura la posicion en Y de los sprites
        SpritePezNormal.transform.position = new Vector2(SpritePezNormal.transform.position.x, posicionPezNormalY);
        SpritePezNormal2.transform.position = new Vector2(SpritePezNormal2.transform.position.x, posicionPezNormal2Y);
        SpritePezRaro.transform.position = new Vector2(SpritePezRaro.transform.position.x, posicionPezRaroY);
        SpriteAlga.transform.position = new Vector2(SpriteAlga.transform.position.x, posicionAlgaY);
        SpriteBota.transform.position = new Vector2(SpriteBota.transform.position.x, posicionBotaY);
        SpriteTesoro.transform.position = new Vector2(SpriteTesoro.transform.position.x, posicionTesoroY);
        //Desactiva el sprite visualmente
        SpritePezNormal.SetActive(false);
        SpritePezNormal2.SetActive(false);
        SpritePezRaro.SetActive(false);
        SpriteBota.SetActive(false);
        SpriteAlga.SetActive(false);
        SpriteTesoro.SetActive(false);
    }

    //Metodo que despliega la captura
    public void DesplegarCaptura(int pesca)
    {
        if(pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenPezNormal.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorPezNormal ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajePezNormal.text = contadorPezNormal.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        }else if(pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenPezNormal2.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorPezNormal2 ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajePezNormal2.text = contadorPezNormal2.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        }else if(pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenPezRaro.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorPezRaro ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajePezRaro.text = contadorPezRaro.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        }else if(pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenAlga.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorAlga ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajeAlga.text = contadorAlga.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        } else if(pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenBota.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorBota ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajeBota.text = contadorBota.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        } else if(pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax)
        {
                //Activa el panel de captura
                PanelCaptura.SetActive(true);
                //Activa la imagen de la captura pertinente
                ImagenTesoro.SetActive(true);
                //Reproduce el sonido de captura
                Instantiate(SonidoCaptura);
                //Suma 1 al contador de la captura pertinente
                contadorTesoro ++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Actualiza el contador visual de la captura pertinente
                puntajeTesoro.text = contadorTesoro.ToString();
                //Actualiza el contador visual total de capturas
                puntajeTotal.text = contadorTotal.ToString();
                //Inicia la corrutina para esperar 3 segundos
                StartCoroutine("Esperar");

        }
    }

    //Desactiva todos los paneles que aparecen cuando capturas algo
    public void QuitarPez()
    {
        ImagenPezNormal.SetActive(false);
        ImagenPezNormal2.SetActive(false);
        ImagenPezRaro.SetActive(false);
        ImagenBota.SetActive(false);
        ImagenAlga.SetActive(false);
        ImagenTesoro.SetActive(false);
        PanelCaptura.SetActive(false);
    }
 
    //Metodo que genera un numero aleatoria del 1 al 100, el cual manda al metodo de CapturaPez para mostrar lo capturado
    public int RNGCaptura()
    {
        System.Random r = new System.Random(); 
        int numero;
        numero = r.Next(1, 101);
        return numero;
    }

    //Corrutina para esperar 3 segundos y se va a desactivar los paneles
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        QuitarPez();
    }
}