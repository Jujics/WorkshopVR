using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quitText;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private string sceneName;

    public void MenuPlay()
    {
        StartCoroutine(ButtonPlay());
    }

    public void MenuQuit()
    {
        StartCoroutine(ButtonQuit());
    }

    public IEnumerator ButtonPlay()
    {
        yield return new WaitForSeconds(0);
        playText.color = Color.blue;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator ButtonQuit()
    {
        yield return new WaitForSeconds(0);
        quitText.color = Color.red;
        yield return new WaitForSeconds(2);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}