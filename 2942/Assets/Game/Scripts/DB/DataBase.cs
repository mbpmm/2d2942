﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviourSingleton<DataBase>
{
    public GameObject profilePanel;
    private bool goToMenu;

    public string id;
    public int score;

    public string[] dataReceivedUser;
    public string[] dataReceivedProfile;
    public string[] dataReceivedGameData;

    [Header("UI")]
    public InputField usernameText;
    public InputField passwordText;
   // public InputField nameText;
   // public InputField lastnameText;
   // public Text scoreText;
    public Text requestText;
   // public Text infoProfileText;

    private void Start()
    {
        //if (SceneManager.GetActiveScene().name == "Profile")
        //{
        //    activateProfilePanel();
        //}
    }

    private void Update()
    {
        if (goToMenu)
        {
            goToMenu = false;
            SceneManager.LoadScene("IntroScene");
        }
    }

    public void registerPlayer()
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
            StartCoroutine(GetRequestRegister("http://localhost/projects/actions.php"));
        }

    }

    IEnumerator GetRequestRegister(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "register");
        form.AddField("user", usernameText.text);
        form.AddField("pass", passwordText.text);

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        // Request and wait for the desired page.
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
            dataReceivedUser = data.Split('=');
            requestText.text = dataReceivedUser[0];
        }
    }

    public void logInPlayer()
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
            StartCoroutine(GetRequestLogIn("http://localhost/projects/actions.php"));
        }
    }

    IEnumerator GetRequestLogIn(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "login");
        form.AddField("user", usernameText.text);
        form.AddField("pass", passwordText.text);

        UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

        // Request and wait for the desired page.
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
            dataReceivedUser = data.Split('=');

            if (dataReceivedUser[0] == "User doesn't exist." || dataReceivedUser[0] == "Password is incorrect.")
            {
                requestText.text = dataReceivedUser[0];
            }
            else
            {
                id = dataReceivedUser[0];
                requestText.text = dataReceivedUser[1];
                goToMenu = true;
            }
        }
    }

    //public void save()
    //{
    //    if (nameText.text == "")
    //    {
    //        infoProfileText.text = "Type a name.";
    //    }
    //    else if (lastnameText.text == "")
    //    {
    //        infoProfileText.text = "Type a last name.";
    //    }
    //    else
    //    {
    //        StartCoroutine(GetRequestSave("http://localhost/unityproject/actions.php"));
    //    }
    //}

    //IEnumerator GetRequestSave(string uri)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("action", "save");
    //    form.AddField("id", id);
    //    form.AddField("name", nameText.text);
    //    form.AddField("lastname", lastnameText.text);

    //    UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

    //    // Request and wait for the desired page.
    //    yield return webRequest.SendWebRequest();

    //    string[] pages = uri.Split('/');
    //    int page = pages.Length - 1;

    //    if (webRequest.isNetworkError)
    //    {
    //        Debug.Log(pages[page] + ": Error: " + webRequest.error);
    //    }
    //    else
    //    {
    //        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

    //        string data;

    //        data = webRequest.downloadHandler.text;
    //        dataReceivedProfile = data.Split('=');
    //        infoProfileText.text = dataReceivedProfile[0];
    //    }
    //}

    //public void load()
    //{
    //    StartCoroutine(GetRequestLoad("http://localhost/unityproject/actions.php"));
    //}

    //IEnumerator GetRequestLoad(string uri)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("action", "load");
    //    form.AddField("id", id);

    //    UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

    //    // Request and wait for the desired page.
    //    yield return webRequest.SendWebRequest();

    //    string[] pages = uri.Split('/');

    //    int page = pages.Length - 1;

    //    if (webRequest.isNetworkError)
    //    {
    //        Debug.Log(pages[page] + ": Error: " + webRequest.error);
    //    }
    //    else
    //    {
    //        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

    //        string data;

    //        data = webRequest.downloadHandler.text;
    //        dataReceivedProfile = data.Split('=');
    //        nameText.text = dataReceivedProfile[0];
    //        lastnameText.text = dataReceivedProfile[1];
    //    }
    //}

    //public void loadpb()
    //{
    //    StartCoroutine(GetRequestLoadPb("http://localhost/unityproject/actions.php"));
    //}

    //IEnumerator GetRequestLoadPb(string uri)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("action", "loadpb");
    //    form.AddField("id", id);

    //    UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

    //    // Request and wait for the desired page.
    //    yield return webRequest.SendWebRequest();

    //    string[] pages = uri.Split('/');

    //    int page = pages.Length - 1;

    //    if (webRequest.isNetworkError)
    //    {
    //        Debug.Log(pages[page] + ": Error: " + webRequest.error);
    //    }
    //    else
    //    {
    //        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

    //        string data;

    //        data = webRequest.downloadHandler.text;
    //        dataReceivedGameData = data.Split('=');
    //        scoreText.text = dataReceivedGameData[0];
    //    }
    //}

    //public void savepb()
    //{
    //    StartCoroutine(GetRequestSavePb("http://localhost/unityproject/actions.php"));
    //}

    //IEnumerator GetRequestSavePb(string uri)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("action", "savepb");
    //    form.AddField("id", id);
    //    form.AddField("score", score.ToString());

    //    UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);

    //    // Request and wait for the desired page.
    //    yield return webRequest.SendWebRequest();

    //    string[] pages = uri.Split('/');
    //    int page = pages.Length - 1;

    //    if (webRequest.isNetworkError)
    //    {
    //        Debug.Log(pages[page] + ": Error: " + webRequest.error);
    //    }
    //    else
    //    {
    //        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
    //    }
    //}

    //public void switchToProfile()
    //{
    //    SceneManager.LoadScene("Profile");
    //    Invoke("activateProfilePanel", 0.5f);
    //}

    //public void activateProfilePanel()
    //{
    //    profilePanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
    //    profilePanel.SetActive(true);
    //    load();
    //    loadpb();
    //}

    //public void deactivateProfilePanel()
    //{
    //    profilePanel.SetActive(false);
    //}
}