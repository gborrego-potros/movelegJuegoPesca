using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioSesionDb : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField password;

    [SerializeField] Text errorMessages;

    [SerializeField] Button loginButton;
    [SerializeField] string url;

    WWWForm form;

    public void OnLoginButtonClicked()
    {
        loginButton.interactable = false;
        StartCoroutine (Login());
    }

    IEnumerator Login()
    {
        form = new WWWForm();

        form.AddField("username", username.text);
        form.AddField("password", password.text);

        Debug.Log("Aqui va la url " + url );

        WWW w = new WWW(url, form);

        yield return w;

        if(w.error != null){
            errorMessages.text = "404 not found!";
        }else{
            if(w.isDone){
                Debug.Log(w.text);
                if(w.text.Contains("error")){
                    errorMessages.text = "invalid username or password!" + username.text + " " + password.text;
                }
                else{
                    SceneManager.LoadScene(1);
                }
            }
        }
        loginButton.interactable = true;
        w.Dispose();
    }
}
