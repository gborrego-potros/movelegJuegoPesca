using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
public class ControladorInicioSesion : MonoBehaviour
{
    [SerializeField] private InputField usuario;
    [SerializeField] private InputField contrasenia;
    [SerializeField] private Text mensaje;
    [SerializeField] private Button continuar;
    [SerializeField] private GameObject canvasInicioSesion;

    //LLENAR INPUTS TEXT DE LA CONFIGURACION DE LA TERAPIA
    [SerializeField] private InputField numRepeticiones;
    [SerializeField] private InputField numRepeticionesRodilla;
    [SerializeField] private InputField numRepeticionesTobillo;

    private string nombreUsuario;
    private string contrasena;

    [ContextMenu("Test Login")]
    public async void IniciarSesion()
    {
        nombreUsuario = usuario.text;
        contrasena = contrasenia.text;

        Debug.Log($"Usuario ingresado: {nombreUsuario}");
        Debug.Log($"Contraseña ingresada: {contrasena}");

        var url = "http://localhost:3000/api/login";

        var datosLogin = new DatosLogin
        {
            correo = nombreUsuario,
            contrasenia = contrasena
        };

        string jsonData = JsonConvert.SerializeObject(datosLogin);
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

        // "{\"mensaje\":\"Login exitoso\",\"correo\":\"admin@example.com\"}" ---- ESTO DE EJEMPLO,
        // Entonces jsonResponse tendrá este valor como string. HACER ALGO SABIO CON ESTO


        try
        {
            Debug.Log("Si entra al try");
            //USAR INDIVIDUAL ATRIBUTOS DEL JSON*****************************
            var json = JObject.Parse(jsonResponse);
            string mensajeServidor = json["mensaje"]?.ToString();
            string token = json["token"]?.ToString();

            //jsonResponse == "{\"mensaje\":\"Login exitoso\"}"
            if (mensajeServidor == "Login exitoso" && !string.IsNullOrEmpty(token))//El juego solo necesita saber si fue exitoso el login
            {
                Debug.Log("Token recibido: " + token);
                DatosGlobales.tokenJWT = token;//Se guarda el token globalmente
                Debug.Log("Token guardado en datos globales: " + DatosGlobales.tokenJWT);
                //se oculta canvas
                canvasInicioSesion.SetActive(false);
                //se inabilita boton continuar
                continuar.interactable = false;

                Debug.Log("Login exitoso: canvas oculto y se muestra nuevo");
                DatosGlobales.nombreUsuario = usuario.text;
                //se carga escena que contiene el canvas de configurar terapia
                SceneManager.LoadScene("Juego1");
                //llenar las opciones de la terapia
                //string respuestaJson = await SolicitarTerapiaSesion();

            }
            else
            {
                mensaje.text = "Error desconocido.";
                continuar.interactable = true;
                Debug.Log("Login fallido: ");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error parseando JSON: " + ex.Message);
        }
    }

}
