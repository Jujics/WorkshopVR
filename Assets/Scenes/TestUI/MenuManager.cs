using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject CanvasQuit;
    [SerializeField] private GameObject CanvasPlay;
    [SerializeField] private GameObject LumiereH;
    [SerializeField] private GameObject LumiereB;

    public void Start()
    {
        CanvasQuit.SetActive(false);
        CanvasPlay.SetActive(false);
        LumiereH.SetActive(false);
        LumiereB.SetActive(false);
    }

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
        CanvasPlay.SetActive(true);
        LumiereH.SetActive(true);
        LumiereB.SetActive(true);
        yield return new WaitForSeconds(2);
        CanvasPlay.SetActive(false);
        LumiereH.SetActive(false);
        LumiereB.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }

    public IEnumerator ButtonQuit()
    {
        yield return new WaitForSeconds(0);
        CanvasQuit.SetActive(true);
        LumiereH.SetActive(true);
        LumiereB.SetActive(true);
        yield return new WaitForSeconds(2);
        CanvasQuit.SetActive(false);
        LumiereH.SetActive(false);
        LumiereB.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}