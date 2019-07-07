using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviourSingleton<DataBase>
{
    public GameObject playerProfile;
    private bool goToMenu;
    public string id;
    public int score;
    public string[] datosUser;
    public string[] datosProfile;
    public InputField usernameText;
    public InputField passwordText;
    public InputField nameText;
    public InputField lastnameText;
    public InputField emailText;
    public Text scoreText;
    public Text requestText;
    public Text playerProfileText;

    private void Start()
    {
        playerProfile.SetActive(false);
    }

    private void Update()
    {
        if (goToMenu)
        {
            goToMenu = false;
            SceneManager.LoadScene("IntroScene");
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            ProfileScreenOn();
        }
    }

    public void Register()
    {
        if (usernameText.text == "")
        {
            requestText.text = "Type a username.";
        }
        else if (passwordText.text == "")
        {
            requestText.text = "Type a password.";
        }
        else
        {
            StartCoroutine(RequestRegister("http://localhost/projects/actions.php"));
        }

    }

    IEnumerator RequestRegister(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "register");
        form.AddField("user", usernameText.text);
        form.AddField("pass", passwordText.text);

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        yield return webRequest.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (webRequest.isNetworkError)
        {
            Debug.Log(pages[page] + ": Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

            string data;
            data = webRequest.downloadHandler.text;
            datosUser = data.Split('=');
            requestText.text = datosUser[0];
        }
    }

    public void LogIn()
    {
        if (usernameText.text == "")
        {
            requestText.text = "Type a username.";
        }
        else if (passwordText.text == "")
        {
            requestText.text = "Type a password.";
        }
        else
        {
            StartCoroutine(RequestLogIn("http://localhost/projects/actions.php"));
        }
    }

    IEnumerator RequestLogIn(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "login");
        form.AddField("user", usernameText.text);
        form.AddField("pass", passwordText.text);

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        yield return webRequest.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (webRequest.isNetworkError)
        {
            Debug.Log(pages[page] + ": Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

            string data;
            data = webRequest.downloadHandler.text;
            datosUser = data.Split('=');

            if (datosUser[0] == "User doesn't exist." || datosUser[0] == "Password is incorrect. Try again.")
            {
                requestText.text = datosUser[0];
            }
            else
            {
                id = datosUser[0];
                requestText.text = datosUser[1];
                goToMenu = true;
            }
        }
    }

    public void Save()
    {
        if (nameText.text == "")
        {
            playerProfileText.text = "Type a name.";
        }
        else if (lastnameText.text == "")
        {
            playerProfileText.text = "Type a last name.";
        }
        else
        {
            StartCoroutine(RequestSave("http://localhost/projects/actions.php"));
        }
    }

    IEnumerator RequestSave(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "save");
        form.AddField("Id", id);
        form.AddField("Nombre", nameText.text);
        form.AddField("Apellido", lastnameText.text);
        form.AddField("Email", emailText.text);
        form.AddField("GameData", score.ToString());

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        yield return webRequest.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (webRequest.isNetworkError)
        {
            Debug.Log(pages[page] + ": Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

            string data;

            data = webRequest.downloadHandler.text;
            datosProfile = data.Split('=');
            playerProfileText.text = datosProfile[0];
        }
    }

    public void Load()
    {
        StartCoroutine(RequestLoad("http://localhost/projects/actions.php"));
    }

    IEnumerator RequestLoad(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "load");
        form.AddField("id", id);

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        yield return webRequest.SendWebRequest();

        string[] pages = uri.Split('/');

        int page = pages.Length - 1;

        if (webRequest.isNetworkError)
        {
            Debug.Log(pages[page] + ": Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

            string data;

            data = webRequest.downloadHandler.text;
            datosProfile = data.Split('=');
            nameText.text = datosProfile[0];
            lastnameText.text = datosProfile[1];
            emailText.text = datosProfile[2];
            scoreText.text = datosProfile[3];
        }
    }

    public void ProfileScreenOn()
    {
        playerProfile.SetActive(true);
        Load();
    }

    public void ProfileScreenOff()
    {
        playerProfile.SetActive(false);
    }
}