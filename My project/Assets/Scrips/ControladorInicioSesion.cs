using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ControladorInicioSesion : MonoBehaviour
{
    [SerializeField] private GameObject usuario;
    [SerializeField] private GameObject contrasenia;
    [SerializeField] private Text mensaje;
    [SerializeField] private Button continuar;

    

    public String nombreUsuario;
    public String contrasena;

    [ContextMenu("Test Get")]
    public async void InciarSesion()
    {
        var url = "http://localhost:3000/api/pacientes/1";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operacion = www.SendWebRequest();

        while (!operacion.isDone)
            await Task.Yield();

        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log($"Failed:{www.error}");

        try
        {
            var result = JsonConvert.DeserializeObject<Usuario>(jsonResponse);
            
            nombreUsuario = result.nombre;
            contrasena = result.contrasenia;

            mensaje.text = nombreUsuario;

            Debug.Log(contrasena);
            /*
            continuar.onClick.AddListener(clickButton){
                
            }
            */
            //Debug.Log($"Success: {www.downloadHandler.text}");
        }
        catch (Exception ex)
        {
            Debug.LogError($" {this} Could not parse response {jsonResponse}. {ex.Message}");
        }
    }

    public void clickButton(){
        /*if(result.nombre.ToString()){
                    
        }
        */
    }
}
