using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumen : MonoBehaviour
{
    //Variables para el control del volumen 
    public Slider controlVolumen;
    public GameObject[] audios;

    //Metodo que encuentra el audio y el nivel del volumen asignado
    private void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("audio");
        controlVolumen.value = PlayerPrefs.GetFloat("volumenSave", 0.5f);
    }
    //Método 
    private void Update()
    {
        foreach(GameObject au in audios)
            au.GetComponent<AudioSource>().volume = controlVolumen.value;
    }
    //Método para guardar el nuevo nivel del volumen
    public void guardarVolumen()
    {
        PlayerPrefs.SetFloat("volumenSave", controlVolumen.value);
    }
}
