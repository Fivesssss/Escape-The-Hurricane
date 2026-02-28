using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void controls() 
    {
        SceneManager.LoadScene("Controls");
    }

    public void tips() 
    {
        SceneManager.LoadScene("Tips");
    }

    public void play() 
    {
        SceneManager.LoadScene("DifficultyLevelSelect");    
    }

    public void menu() 
    {
        SceneManager.LoadScene("StartScreen");
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

    public void easy() 
    {
        SceneManager.LoadScene("Easy");
    }

    public void medium()
    {
        SceneManager.LoadScene("Medium");
    }

    public void hard()
    {
        SceneManager.LoadScene("Hard");
    }
}
