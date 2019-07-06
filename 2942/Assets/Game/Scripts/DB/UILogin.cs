using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject registerLogin;
    public Text titleTextLogin;
    public Text titleTextRegister;
    public Button registerButton;
    public Button loginButton;

    // Start is called before the first frame update
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

        titleTextLogin.gameObject.SetActive(true);
        titleTextRegister.gameObject.SetActive(false);

        optionsPanel.SetActive(false);
    }

    public void RegisterWindow()
    {
        optionsPanel.SetActive(false);
        registerLogin.SetActive(true);
        loginButton.gameObject.SetActive(false);
        registerButton.gameObject.SetActive(true);

        titleTextLogin.gameObject.SetActive(false);
        titleTextRegister.gameObject.SetActive(true);
    }

    public void Options()
    {
        titleTextLogin.gameObject.SetActive(false);
        titleTextRegister.gameObject.SetActive(false);
        optionsPanel.SetActive(true);
        registerLogin.SetActive(false);
    }
}