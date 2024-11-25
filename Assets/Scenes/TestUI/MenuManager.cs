using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    public static GameObject menuMenu, quitMenu;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        menuMenu = canvas.transform.Find("MenuMenu").gameObject;
        quitMenu = canvas.transform.Find("QuitMenu").gameObject;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!menuMenu || !quitMenu)
            Init();

        switch (menu)
        {
            case Menu.MENU:
                menuMenu.SetActive(true);
                MenuPlay();
                break;
                
            case Menu.QUIT:
                quitMenu.SetActive(true);
                MenuQuit();
                break;
        }

        callingMenu.SetActive(false);
    }

    private static void MenuPlay()
    {
        throw new NotImplementedException();
    }

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