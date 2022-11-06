using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultadoPuntaje : MonoBehaviour
{
    //Textos de puntuacion de las cosas atrapadas
    [SerializeField] private Text pecesNormales;
    [SerializeField] private Text pecesNormalesR;
    [SerializeField] private Text pecesNormales2;
    [SerializeField] private Text pecesNormales2R;
    [SerializeField] private Text pecesRaros;
    [SerializeField] private Text pecesRarosR;
    [SerializeField] private Text botas;
    [SerializeField] private Text botasR;
    [SerializeField] private Text algas;
    [SerializeField] private Text algasR;
    [SerializeField] private Text tesoros;
    [SerializeField] private Text tesorosR;

    //Imagen de Resumen de la Pesca
    [SerializeField] private GameObject resumenPesca;
    //Canvas de Puntajes
    [SerializeField] private GameObject canvasResultados;
    [SerializeField] private GameObject personaje;
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject textoPantallaPrincipal;

    /*
    
    */
    [SerializeField] private GameObject fondo;
    //Método que despliega la puntacion final de la captura
    public void puntajeDesplegar(int numPecesNormales, int numPecesNormales2, int numPecesRaros, int numBotas, int numAlgas, int numTesoros,
    int numPecesNormalesR, int numPecesNormales2R, int numPecesRarosR, int numBotasR, int numAlgasR, int numTesorosR)
    {
        //Asigna los resultados de las cosas atrapadas al resumen final
        pecesNormales.text = numPecesNormales.ToString();
        pecesNormales2.text = numPecesNormales2.ToString();
        pecesRaros.text = numPecesRaros.ToString();
        botas.text = numBotas.ToString();
        algas.text = numAlgas.ToString();
        tesoros.text = numTesoros.ToString();

        pecesNormalesR.text = "|| " + numPecesNormalesR.ToString();
        pecesNormales2R.text = "|| " + numPecesNormales2R.ToString();
        pecesRarosR.text = "|| " + numPecesRarosR.ToString();
        botasR.text = "|| " + numBotasR.ToString();
        algasR.text = "|| " + numAlgasR.ToString();
        tesorosR.text = "|| " + numTesorosR.ToString();

        //Activa el resumen final
        resumenPesca.SetActive(true);
        canvasResultados.SetActive(true);

        //Desactiva la pantalla del juego
        personaje.SetActive(false);
        botonPausa.SetActive(false);
        textoPantallaPrincipal.SetActive(false);
        fondo.SetActive(false);
    }
}
