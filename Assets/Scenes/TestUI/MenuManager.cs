using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void MenuPlay(string sceneName)
    {
        Debug.Log("sceneName to Load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public static void MenuQuit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}