using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PruebaMensajesPantalla : MonoBehaviour
{
    void Start ()
    {
        bool decision = EditorUtility.DisplayDialog(
            "Exit Game", 
            "Are you sure you want to exit the game?",
            "Yes",
            "No"
        );

        if(decision){
            Debug.Log(decision);
            Debug.Log("Exit Game");
        }else{
            Debug.Log(decision);
            Debug.Log("Continue Playing");
        }
            
    }

}
