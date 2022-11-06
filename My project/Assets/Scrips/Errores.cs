using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Errores : MonoBehaviour
{
    private static ILogger logger = Debug.unityLogger;
    private static string kTAG = "MyGameTag";
    private MyFileLogHandler myFileLogHandler;

    void Start()
    {
        myFileLogHandler = new MyFileLogHandler();

        //logger.Log(kTAG, "Errores Start.");
    }
}

