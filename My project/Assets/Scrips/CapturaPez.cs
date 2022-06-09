using System.Collections;
using System.Collections.Generic;
using static System.Random;
using System;
using UnityEngine;

public class CapturaPez : MonoBehaviour
{
    [SerializeField] private GameObject ImagenPezNormal;
    [SerializeField] private GameObject ImagenPezNormal2;
    [SerializeField] private GameObject ImagenPezRaro;
    [SerializeField] private GameObject ImagenBota;
    [SerializeField] private GameObject ImagenAlga;
    [SerializeField] private GameObject ImagenTesoro;
    [SerializeField] private GameObject PanelCaptura;

    ResultadoPuntaje puntaje;

    public int contadorPezNormal = 0;
    public int contadorPezNormal2 = 0;
    public int contadorPezRaro = 0;
    public int contadorBota = 0;
    public int contadorAlga = 0;
    public int contadorTesoro = 0;

    public int porcentajePezNormalMin = 1;
    public int porcentajePezNormalMax = 20;

    public int porcentajePezNormal2Min = 21;
    public int porcentajePezNormal2Max = 40;

    public int porcentajePezRaroMin = 41;
    public int porcentajePezRaroMax = 50;

    public int porcentajeAlgaMin = 51;
    public int porcentajeAlgaMax = 70;

    public int porcentajeBotaMin = 71;
    public int porcentajeBotaMax = 90;

    public int porcentajeTesoroMin = 91;
    public int porcentajeTesoroMax = 100;

    void Start()
    {
        //RNGCaptura();
    }

    void CapturarPez(int pesca)
    {
        if(pesca >= porcentajePezNormalMin && pesca <= porcentajePezNormalMax){
                PanelCaptura.SetActive(true);
                ImagenPezNormal.SetActive(true);
                contadorPezNormal ++;
                StartCoroutine("Esperar");
        }else if(pesca >= porcentajePezNormal2Min && pesca <= porcentajePezNormal2Max){
                PanelCaptura.SetActive(true);
                ImagenPezNormal2.SetActive(true);
                contadorPezNormal2 ++;
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajePezRaroMin && pesca <= porcentajePezRaroMax){
                PanelCaptura.SetActive(true);
                ImagenPezRaro.SetActive(true);
                contadorPezRaro ++;
                StartCoroutine("Esperar");
        }else if(pesca >= porcentajeAlgaMin && pesca <= porcentajeAlgaMax){
                PanelCaptura.SetActive(true);
                ImagenAlga.SetActive(true);
                contadorAlga ++;
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajeBotaMin && pesca <= porcentajeBotaMax){
                PanelCaptura.SetActive(true);
                ImagenBota.SetActive(true);
                contadorBota ++;
                StartCoroutine("Esperar");
        } else if(pesca >= porcentajeTesoroMin && pesca <= porcentajeTesoroMax){
                PanelCaptura.SetActive(true);
                ImagenTesoro.SetActive(true);
                contadorTesoro ++;
                StartCoroutine("Esperar");
        }
        
    }

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

    public void RNGCaptura()
    {
        System.Random r = new System.Random(); 
        int numero;
        numero = r.Next(1, 101);
        CapturarPez(numero);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        QuitarPez();
    }
}