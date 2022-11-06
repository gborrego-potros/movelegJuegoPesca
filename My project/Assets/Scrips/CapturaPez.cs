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

    //Contadores de capturas
    public int contadorPezNormalR = 0;
    public int contadorPezNormal2R = 0;
    public int contadorPezRaroR = 0;
    public int contadorBotaR = 0;
    public int contadorAlgaR = 0;
    public int contadorTesoroR = 0;

    //Contadores de capturas
    public int contadorPezNormalVisual = 0;
    public int contadorPezNormal2Visual = 0;
    public int contadorPezRaroVisual = 0;
    public int contadorBotaVisual = 0;
    public int contadorAlgaVisual = 0;
    public int contadorTesoroVisual = 0;

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

    //Valor del puntaje de cada cosa a capturar
    public int valorPezNormal = 150;
    public int valorPezNormal2 = 150;
    public int valorPezRaro = 500;
    public int valorAlga = 100;
    public int valorBota = 100;
    public int valorTesoro = 1000;

    public int Score = 0;
    public int ScoreR = 0;

    //Variables para la animacion
    float velocidad = 7f;
    float tiempoEspera = 0;
    int pesca;

    //Posicion original en Y de los sprites de captura
    float posicionPezNormalY;
    float posicionPezNormal2Y;
    float posicionPezRaroY;
    float posicionBotaY;
    float posicionAlgaY;
    float posicionTesoroY;

    void Start()
    {
        if (Screen.width >= 800 && Screen.height >= 480 && Screen.width < 1280)
        {
            tiempoEspera = 20f;
        }
        else if (Screen.width >= 1024 && Screen.height >= 600 && Screen.width < 1280)
        {
            tiempoEspera = 20f;
        }
        else if (Screen.width >= 1280 && Screen.height >= 720 && Screen.width < 1920)
        {
            velocidad = 9f;
            tiempoEspera = 21f;
        }
        else if (Screen.width >= 1920 && Screen.height >= 720 && Screen.width < 2160)
        {
            velocidad = 12f;
            tiempoEspera = 24f;
        }
        else if (Screen.width >= 2160 && Screen.height >= 1080 && Screen.width < 2560)
        {
            velocidad = 13.2f;
            tiempoEspera = 21f;
        }
        else if (Screen.width >= 2560 && Screen.height >= 1440 && Screen.width < 2960 && Screen.height < 1700)
        {
            velocidad = 17f;
            tiempoEspera = 21f;
        }
        else if (Screen.width >= 2800 && Screen.height >= 1752)
        {
            velocidad = 19f;
            tiempoEspera = 22f;
        }
        else if (Screen.width >= 2960 && Screen.height >= 1440)
        {
            velocidad = 20f;
            tiempoEspera = 21f;
        }
        else
        {
            velocidad = 12f;
            tiempoEspera = 24f;
        }
    }

    //Metodo que activa la corrutina la cual realiza la animacion de captura
    public void iniciarAnimacion(int pescaRNG)
    {
        pesca = pescaRNG;
        posicionPezNormalY = SpritePezNormal.transform.position.y;
        posicionPezNormal2Y = SpritePezNormal2.transform.position.y;
        posicionPezRaroY = SpritePezRaro.transform.position.y;
        posicionBotaY = SpriteBota.transform.position.y;
        posicionAlgaY = SpriteAlga.transform.position.y;
        posicionTesoroY = SpriteTesoro.transform.position.y;
        StartCoroutine("animacionCapturar");
    }

    public int getScore()
    {
        return Score;
    }

    public int getScoreR()
    {
        return ScoreR;
    }

    public void resetContadores()
    {
        contadorPezNormalVisual = 0;
        puntajePezNormal.text = contadorPezNormalVisual.ToString();
        contadorPezNormal2Visual = 0;
        puntajePezNormal2.text = contadorPezNormal2Visual.ToString();
        contadorPezRaroVisual = 0;
        puntajePezRaro.text = contadorPezRaroVisual.ToString();
        contadorBotaVisual = 0;
        puntajeBota.text = contadorBotaVisual.ToString();
        contadorAlgaVisual = 0;
        puntajeAlga.text = contadorAlgaVisual.ToString();
        contadorTesoroVisual = 0;
        puntajeTesoro.text = contadorTesoroVisual.ToString();
        contadorTotal = 0;
        puntajeTotal.text = contadorTotal.ToString();
    }

    //Corrutina para la animacion de captura
    IEnumerator animacionCapturar()
    {

        for (int x = 0; x != tiempoEspera; x++)
        {
            if (pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax)
            {
                //Activa el sprite de la captura pertinente para la animacion
                SpritePezNormal.SetActive(true);
                //Llama a la animacion
                SpritePezNormal.transform.position = new Vector2(SpritePezNormal.transform.position.x, SpritePezNormal.transform.position.y + velocidad);
                yield return new WaitForSeconds(0.1f);

            }
            else if (pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max)
            {
                //Activa el sprite de la captura pertinente para la animacion
                SpritePezNormal2.SetActive(true);
                //Llama a la animacion
                SpritePezNormal2.transform.position = new Vector2(SpritePezNormal2.transform.position.x, SpritePezNormal2.transform.position.y + velocidad);
                yield return new WaitForSeconds(0.1f);

            }
            else if (pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax)
            {
                //Activa el sprite de la captura pertinente para la animacion
                SpritePezRaro.SetActive(true);
                //Llama a la animacion
                SpritePezRaro.transform.position = new Vector2(SpritePezRaro.transform.position.x, SpritePezRaro.transform.position.y + velocidad);
                yield return new WaitForSeconds(0.1f);

            }
            else if (pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax)
            {
                //Activa el sprite de la captura pertinente para la animacion
                SpriteAlga.SetActive(true);
                //Llama a la animacion
                SpriteAlga.transform.position = new Vector2(SpriteAlga.transform.position.x, SpriteAlga.transform.position.y + velocidad);
                yield return new WaitForSeconds(0.1f);

            }
            else if (pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax)
            {
                //Activa el sprite de la captura pertinente para la animacion
                SpriteBota.SetActive(true);
                //Llama a la animacion
                SpriteBota.transform.position = new Vector2(SpriteBota.transform.position.x, SpriteBota.transform.position.y + velocidad);
                yield return new WaitForSeconds(0.1f);

            }
            else if (pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax)
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
    public void DesplegarCaptura(int pesca, int esRepeticionR)
    {
        if (pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenPezNormal.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezNormal++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorPezNormal;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezNormalR++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorPezNormal;
            }
            //Aumenta el contador visual
            contadorPezNormalVisual++;
            //Actualiza el contador visual de la captura pertinente
            puntajePezNormal.text = contadorPezNormalVisual.ToString();
            //Actualiza el contador visual total de capturas
            puntajeTotal.text = contadorTotal.ToString();
            //Inicia la corrutina para esperar 3 segundos
            StartCoroutine("Esperar");

        }
        else if (pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenPezNormal2.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezNormal2++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorPezNormal2;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezNormal2R++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorPezNormal2;
            }
            //Aumenta el contador visual
            contadorPezNormal2Visual++;
            //Actualiza el contador visual de la captura pertinente
            puntajePezNormal2.text = contadorPezNormal2Visual.ToString();
            //Actualiza el contador visual total de capturas
            puntajeTotal.text = contadorTotal.ToString();
            //Inicia la corrutina para esperar 3 segundos
            StartCoroutine("Esperar");

        }
        else if (pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenPezRaro.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezRaro++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorPezRaro;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorPezRaroR++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorPezRaro;
            }
            //Aumenta el contador visual
            contadorPezRaroVisual++;
            //Actualiza el contador visual de la captura pertinente
            puntajePezRaro.text = contadorPezRaroVisual.ToString();
            //Actualiza el contador visual total de capturas
            puntajeTotal.text = contadorTotal.ToString();
            //Inicia la corrutina para esperar 3 segundos
            StartCoroutine("Esperar");

        }
        else if (pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenAlga.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorAlga++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorAlga;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorAlgaR++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorAlga;
            }
            //Aumenta el contador visual
            contadorAlgaVisual++;
            //Actualiza el contador visual de la captura pertinente
            puntajeAlga.text = contadorAlgaVisual.ToString();
            //Actualiza el contador visual total de capturas
            puntajeTotal.text = contadorTotal.ToString();
            //Inicia la corrutina para esperar 3 segundos
            StartCoroutine("Esperar");

        }
        else if (pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenBota.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorBota++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorBota;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorBotaR++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorBota;
            }
            //Aumenta el contador visual
            contadorBotaVisual++;
            //Actualiza el contador visual de la captura pertinente
            puntajeBota.text = contadorBotaVisual.ToString();
            //Actualiza el contador visual total de capturas
            puntajeTotal.text = contadorTotal.ToString();
            //Inicia la corrutina para esperar 3 segundos
            StartCoroutine("Esperar");

        }
        else if (pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax)
        {
            //Activa el panel de captura
            PanelCaptura.SetActive(true);
            //Activa la imagen de la captura pertinente
            ImagenTesoro.SetActive(true);
            //Reproduce el sonido de captura
            Instantiate(SonidoCaptura);
            //Valora si es una repeticion de rodilla o tobillo
            if (esRepeticionR == 1)
            {
                //Suma 1 al contador de la captura pertinente
                contadorTesoro++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                Score = Score + valorTesoro;
            }
            else
            {
                //Suma 1 al contador de la captura pertinente
                contadorTesoroR++;
                //Suma 1 al contador total de capturas
                contadorTotal++;
                //Suma al score el valor de la captura
                ScoreR = ScoreR + valorTesoro;
            }
            //Aumenta el contador visual
            contadorTesoroVisual++;
            //Actualiza el contador visual de la captura pertinente
            puntajeTesoro.text = contadorTesoroVisual.ToString();
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