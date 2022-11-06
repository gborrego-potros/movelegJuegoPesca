using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mensajes : MonoBehaviour
{
    public Control cambioEscena;
    public GameObject canvasMensajes;

    public Button botonConfirmar;

    public Button botonCancelar;

    public Text mensaje;

    private bool confirmacion;

    // Start is called before the first frame update
    void Start()
    {
        confirmacion = false;
    }

    public void SetMensaje(string texto)
    {
        mensaje.text = texto;
    }

    public void funcionBotonConfirmar()
    {
        confirmacion = true;
        OcultarCanvas();
        Time.timeScale = 1f;
    }

    public void funcionBotonConfirmarError(){
        botonConfirmar.onClick.AddListener(cambiarEscena);
    }

    public void cambiarEscena(){
        cambioEscena.CargarEscena("Main_Menu");
    }

    
    public void funcionBotonCancelar()
    {
        confirmacion = false;
        cambiarEscena();
        Time.timeScale = 1f;
    }

    public bool GetConfirmacion()
    {
        return confirmacion;
    }

    public void ActivarCanvas(){
        canvasMensajes.SetActive(true);
    }

    public void OcultarCanvas(){
        canvasMensajes.SetActive(false);
        //confirmacion = false;
    }

    public void ActivarBotonCancelar(){
        botonCancelar.gameObject.SetActive(true);
    }

    public void OcultarBotonCancelar(){
        botonCancelar.gameObject.SetActive(false);
    }
}
