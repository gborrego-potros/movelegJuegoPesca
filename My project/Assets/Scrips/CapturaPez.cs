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

    void Start()
    {
        //RNGCaptura();
    }

    public void CapturarPez(int pesca)
    {
        if(pesca == 1 || pesca == 2){
                PanelCaptura.SetActive(true);
                ImagenPezNormal.SetActive(true);
                contadorPezNormal ++;
                StartCoroutine("Esperar");
        }else if(pesca == 3 || pesca == 4){
                PanelCaptura.SetActive(true);
                ImagenPezNormal2.SetActive(true);
                contadorPezNormal2 ++;
                StartCoroutine("Esperar");
        } else if(pesca == 5){
                PanelCaptura.SetActive(true);
                ImagenPezRaro.SetActive(true);
                contadorPezRaro ++;
                StartCoroutine("Esperar");
        }else if(pesca == 6 || pesca == 7){
                PanelCaptura.SetActive(true);
                ImagenAlga.SetActive(true);
                contadorAlga ++;
                StartCoroutine("Esperar");
        } else if(pesca == 8 || pesca == 9){
                PanelCaptura.SetActive(true);
                ImagenBota.SetActive(true);
                contadorBota ++;
                StartCoroutine("Esperar");
        } else if(pesca == 10){
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
        numero = r.Next(1, 11);
        Debug.Log(numero);
        CapturarPez(numero);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        QuitarPez();
        StopAllCoroutines();
    }
}