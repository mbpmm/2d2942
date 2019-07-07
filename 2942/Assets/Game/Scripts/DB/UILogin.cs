using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject registerLogin;
    public Button registerButton;
    public Button loginButton;
    public Text textLogin;
    public Text textRegister;
    void Start()
    {
        optionsPanel.SetActive(true);
        registerLogin.SetActive(false);
    }

    public void LoginWindow()
    {
        registerLogin.SetActive(true);
        loginButton.gameObject.SetActive(true);
        registerButton.gameObject.SetActive(false);
        textLogin.gameObject.SetActive(true);
        textRegister.gameObject.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void RegisterWindow()
    {
        optionsPanel.SetActive(false);
        registerLogin.SetActive(true);
        loginButton.gameObject.SetActive(false);
        registerButton.gameObject.SetActive(true);
        textLogin.gameObject.SetActive(false);
        textRegister.gameObject.SetActive(true);
    }

    public void Options()
    {
        textLogin.gameObject.SetActive(false);
        textRegister.gameObject.SetActive(false);
        optionsPanel.SetActive(true);
        registerLogin.SetActive(false);
    }
}