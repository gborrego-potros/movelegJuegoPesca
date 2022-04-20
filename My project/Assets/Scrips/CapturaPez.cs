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
    
    //Falta que se quite el despliegue de la imagen tras unos segundos
    public void CapturarPez(int pesca)
    {
        switch(pesca)
        {
            case 1:
                Console.WriteLine("Pez normal");
                ImagenPezNormal.SetActive(true);
                break;
            case 2:
                Console.WriteLine("Pez normal 2");
                ImagenPezNormal2.SetActive(true);
                break;
            case 3:
                Console.WriteLine("Pez raro");
                ImagenPezRaro.SetActive(true);
                break;
            case 4:
                Console.WriteLine("Alga");
                ImagenBota.SetActive(true);
                break;
            case 5:
                Console.WriteLine("Bota");
                ImagenAlga.SetActive(true);
                break;
            case 6:
                Console.WriteLine("Cofre");
                ImagenTesoro.SetActive(true);
                break;
            default:
                Console.WriteLine("Numero fuera del rango");
                break;
        }
    }

    public void RNGCaptura()
    {
            System.Random r = new System.Random();
            int numero;
            numero = r.Next(1,7);
            CapturarPez(numero);
    }
}
