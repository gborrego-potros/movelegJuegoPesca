using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class ControladorDatosTerapia : MonoBehaviour
{
    //COMPONENTES DE LA UI
    //[SerializeField] private InputField usuario;
    private string usuario;
    [SerializeField] private Text mensaje;
    [SerializeField] private InputField numRepeticiones;
    [SerializeField] private InputField numRepeticionesRodilla;
    [SerializeField] private InputField numRepeticionesTobillo;
    [SerializeField] private Button iniciar;
    [SerializeField] private Button solicitar;

    [ContextMenu("Get Terapia")]
    public async void SolicitarTerapia()
    {
        //URL de la apiRest
        var url = "http://localhost:3000/api/configuracionsesiones/SolicitarTerapia";
        string nombre = DatosGlobales.nombreUsuario;
        usuario = nombre;

        //Cuerpo de la peticion
        var datosSolTerapia = new DatosSolTerapia
        {
            correo = usuario
        };
        string jsonData = JsonConvert.SerializeObject(datosSolTerapia);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using var www = new UnityWebRequest(url, "POST");
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        var operacion = www.SendWebRequest();
        while (!operacion.isDone)
            await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error de conexión: {www.error}");
            mensaje.text = "No se pudo conectar al servidor.";
            return;
        }

        var jsonResponse = www.downloadHandler.text;
        Debug.Log("JSON recibido: " + jsonResponse);
        Debug.Log("¿Está vacío?: " + string.IsNullOrEmpty(jsonResponse));

        try
        {
            // var json = JObject.Parse(jsonResponse); //esto es para el metodo de asignarNumeroRepeticiones
            //string numRepeticiones = json["mensaje"]?.ToString();
            //string nrr = json["correo"]?.ToString();
            //string nrt = json["correo"]?.ToString();
            //  string mensajeServidor = json["mensaje"]?.ToString();
            Debug.Log("Si entra al try - solicitar terapia");
 if (jsonResponse.Contains("Paciente si tiene terapia recetada"))
{
    mensaje.text = "Sí tiene terapia recetada";
    iniciar.interactable = true;
    Debug.Log("Sí se tiene la terapia recetada");

    // Esperamos la respuesta del servidor
   string jsonTerapia = await SolicitarTerapiaSesion();

if (string.IsNullOrEmpty(jsonTerapia))
{
    Debug.LogWarning("No se recibió JSON de la terapia.");
    mensaje.text = "Error al obtener la terapia.";
    return;
}

// Validar que sea un JSON de objeto, no un string plano
if (jsonTerapia.Trim().StartsWith("{"))
{
                    try
                    {
                        var respuestaJson = JObject.Parse(jsonTerapia);

                        string nrr = respuestaJson["numRepRodilla"]?.ToString();
                        string nrt = respuestaJson["numRepTobillo"]?.ToString();


                        if (!string.IsNullOrEmpty(nrr)) numRepeticionesRodilla.text = nrr;
                        if (!string.IsNullOrEmpty(nrt)) numRepeticionesTobillo.text = nrt;

                        // Convertir a int para sumar
                        int repRodilla = int.TryParse(nrr, out int r) ? r : 0;
                        int repTobillo = int.TryParse(nrt, out int t) ? t : 0;

                        int total = 4;
                        numRepeticiones.text = total.ToString();

                        Debug.Log("Total repeticiones: " + total.ToString());
                        Debug.Log("Rodilla: " + nrr);
                        Debug.Log("Tobillo: " + nrt);
                        
                        solicitar.interactable = false;
    }
                    catch (Exception ex)
                    {
                        Debug.LogError("Error al interpretar JSON de terapia: " + ex.Message);
                        mensaje.text = "No se pudo procesar la terapia.";
                    }
}
else
{
    Debug.LogWarning("La respuesta de la terapia no es un objeto JSON válido.");
    mensaje.text = "Respuesta inesperada del servidor.";
}

}

            else
            {
                mensaje.text = "No tiene terapia recetada - esperar";
                Debug.Log("No se tiene la terapia recetada");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error parseando JSON: " + ex.Message);
        }
    }
    
      public async Task<string> SolicitarTerapiaSesion()
{
    var url = "http://localhost:3000/api/configuracionsesiones";
    string nombre = DatosGlobales.nombreUsuario;
    //usuario = nombre;

    var datosSolTerapia = new DatosSolTerapia
    {
        correo = nombre
    };

    string jsonData = JsonConvert.SerializeObject(datosSolTerapia);
    byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

    using var www = new UnityWebRequest(url, "POST");
    www.uploadHandler = new UploadHandlerRaw(bodyRaw);
    www.downloadHandler = new DownloadHandlerBuffer();
    www.SetRequestHeader("Content-Type", "application/json");

    var operacion = www.SendWebRequest();
    while (!operacion.isDone)
        await Task.Yield();

    if (www.result != UnityWebRequest.Result.Success)
    {
        Debug.LogError($"Error de conexión: {www.error}");
        return null;
    }

    string jsonResponse = www.downloadHandler.text;
    Debug.Log("Respuesta JSON: " + jsonResponse);

    return jsonResponse;
}
    
}
