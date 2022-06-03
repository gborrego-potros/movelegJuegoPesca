using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ControladorDatosTerapia : MonoBehaviour
{
    public Text textElement;
    [SerializeField] private GameObject botonVolver;
    [SerializeField] private GameObject botonIniciarTerapia;

    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var url= "http://localhost:3000/api/terapias/1";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operacion = www.SendWebRequest();

        while (!operacion.isDone)
            await Task.Yield(); 

        var jsonResponse = www.downloadHandler.text;

        if(www.result != UnityWebRequest.Result.Success)
            Debug.LogError($"Failed: {www.error}"); 

        try
        {
            var result = JsonConvert.DeserializeObject<Terapia>(jsonResponse);
            textElement.text = result.fechaInicio.ToString();
            Debug.Log($"Sucess: {www.downloadHandler.text}");
            
        }
        catch(Exception ex)
        {
            Debug.LogError($" {this} Could not parse response {jsonResponse}. {ex.Message}");
        }

    }
}
