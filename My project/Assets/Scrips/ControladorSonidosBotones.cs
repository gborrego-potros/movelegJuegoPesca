using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidosBotones : MonoBehaviour
{

    public GameObject SonidoClick;

    public void BotonSonClick()
    {
        Instantiate(SonidoClick);
    }
}
