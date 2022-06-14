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

    //
    void CapturarPez(int pesca)
    {
        if(pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax){
                PanelCaptura.SetActive(true);
                ImagenPezNormal.SetActive(true);
                contadorPezNormal ++;
                contadorTotal++;
                puntajePezNormal.text = contadorPezNormal.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        }else if(pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max){
                PanelCaptura.SetActive(true);
                ImagenPezNormal2.SetActive(true);
                contadorPezNormal2 ++;
                contadorTotal++;
                puntajePezNormal2.text = contadorPezNormal2.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax){
                PanelCaptura.SetActive(true);
                ImagenPezRaro.SetActive(true);
                contadorPezRaro ++;
                contadorTotal++;
                puntajePezRaro.text = contadorPezRaro.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        }else if(pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax){
                PanelCaptura.SetActive(true);
                ImagenAlga.SetActive(true);
                contadorAlga ++;
                contadorTotal++;
                puntajeAlga.text = contadorAlga.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax){
                PanelCaptura.SetActive(true);
                ImagenBota.SetActive(true);
                contadorBota ++;
                contadorTotal++;
                puntajeBota.text = contadorBota.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax){
                PanelCaptura.SetActive(true);
                ImagenTesoro.SetActive(true);
                contadorTesoro ++;
                contadorTotal++;
                puntajeTesoro.text = contadorTesoro.ToString();
                puntajeTotal.text = contadorTotal.ToString();
                StartCoroutine("Esperar");
        }
    }

    //
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

    //
    public void RNGCaptura()
    {
        System.Random r = new System.Random(); 
        int numero;
        numero = r.Next(1, 101);
        CapturarPez(numero);
    }

    //
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        QuitarPez();
    }
}