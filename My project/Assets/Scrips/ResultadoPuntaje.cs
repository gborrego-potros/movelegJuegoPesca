using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultadoPuntaje : MonoBehaviour
{

    [SerializeField] private Text pecesNormales;
    [SerializeField] private Text pecesNormales2;
    [SerializeField] private Text pecesRaros;
    [SerializeField] private Text botas;
    [SerializeField] private Text algas;
    [SerializeField] private Text tesoros;

    // Imagen de Resumen de la Pesca
    [SerializeField] private GameObject resumenPesca;
    // Canvas de Puntajes
    [SerializeField] private GameObject canvasResultados;
    [SerializeField] private GameObject canvasPausaPersonaje;
    [SerializeField] private GameObject fondo;

    public void puntajeDesplegar(int numPecesNormales, int numPecesNormales2, int numPecesRaros, int numBotas, int numAlgas, int numTesoros)
    {
        
        pecesNormales.text = numPecesNormales.ToString();
        pecesNormales2.text = numPecesNormales2.ToString();
        pecesRaros.text = numPecesRaros.ToString();
        botas.text = numBotas.ToString();
        algas.text = numAlgas.ToString();
        tesoros.text = numTesoros.ToString();

        resumenPesca.SetActive(true);
        canvasResultados.SetActive(true);

        canvasPausaPersonaje.SetActive(false);
        fondo.SetActive(false);
    }
}
