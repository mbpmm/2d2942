using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFinalScene : MonoBehaviour
{
    public Text score;
    public Text enemiesDestroyed;
    public Text win;
    public Text lose;

    private GameObject gameManager;
    private GameManager manager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        if (manager.win)
        {
            lose.gameObject.SetActive(false);
        }
        else
        {
            win.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        score.text = "Score: " + manager.score;
        enemiesDestroyed.text = "enemies Destroyed: " + manager.enemiesDestroyed;

    }

    public void GoToMenu()
    {
        Destroy(gameManager);
        SceneManager.LoadScene("IntroScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }


}