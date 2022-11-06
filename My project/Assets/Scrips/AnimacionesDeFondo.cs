using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesDeFondo : MonoBehaviour
{

    public AnimacionAve animacionAve;
    public AnimacionPeces animacionPeces;
   
    int x = 0;

    int tiempo;

    int Espera = 100;

    // Start is called before the first frame update
    void Start()
    {
        if(Screen.width >= 800 && Screen.height >= 480 && Screen.width < 1280 ){
            tiempo = 20;
        }else if(Screen.width >= 1280 && Screen.height >= 720 && Screen.width < 1920){
            tiempo = 30;
        }else if(Screen.width >= 1920 && Screen.height >= 720 && Screen.width < 2160){
            tiempo = 40;
        }else if(Screen.width >= 2160 && Screen.height >= 1080 && Screen.width < 2560){
            tiempo = 50;
        }else if(Screen.width >= 2560 && Screen.height >= 1440 && Screen.width < 2960){
            tiempo = 60;
        }else if(Screen.width >= 2960 && Screen.height >= 1440){
            tiempo = 70;
        }else{
            tiempo = 40;
        }
        StartCoroutine("iniciarPesca");
    }

    //Corrutina que inicia todo el proceso de pesca.
    IEnumerator iniciarPesca()
    {
        //Debug.Log("Ancho: " + Screen.width + " Altura: " + Screen.height);

        while (x != Espera)
        {
            animacionPeces.animacionIniciar(tiempo);
            animacionAve.animacionIniciar(tiempo);
            yield return new WaitForSeconds(8f);
        }
    }
}
