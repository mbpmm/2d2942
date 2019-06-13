using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIIntroScene : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void GoToLevel1()
    {
        LoaderManager.Get().LoadScene("Level1");
        UILoadingScreen.Get().SetVisible(true);
    }

    public void GoToLevel2()
    {
        LoaderManager.Get().LoadScene("Level2");
        UILoadingScreen.Get().SetVisible(true);
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
