using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //Variables
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject avatar;
    
    //Método para poner pausa al juego y mostrar el menu de pausa
    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        avatar.SetActive(false);
    }
    //Método para quitar la pausa y continuar el juego
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        avatar.SetActive(true);
    }
    //Método para reiniciar la partida
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Método que cierra la aplicacion
    public void Cerrar ()
    {
        Application.Quit();
    }
}
