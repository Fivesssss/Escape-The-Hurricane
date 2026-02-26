using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void tutorial() 
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void play() 
    {
        SceneManager.LoadScene("DifficultyLevelSelect");    
    }

    public void quit() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBGL
                Application.ExternalEval("window.close();");
        #elif UNITY_STANDALONE
                Application.Quit();
        #else
                Application.Quit();
        #endif
    }
}
