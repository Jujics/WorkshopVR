using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeManager : MonoBehaviour
{
    public int[] CodeHolder;
    public TextMeshProUGUI[] CodeText;
    public int currentLoc = 0;
    public GameObject gameManagerHolder;


    GameManager gameManager;

    public void Start()
    {
        gameManager = gameManagerHolder.GetComponent<GameManager>();
    }

    public void Update()
    {
        for (int i = 0; i < CodeText.Length; i++)
        {
            CodeText[i].text = CodeHolder[i].ToString();
        }
    }

    public void OnButtonClic(int code)
    {
        CodeHolder[currentLoc] = code;
        currentLoc++;
    }

    public void OnValidateButton()
    {
        string Fcode = string.Join(',', CodeHolder);
        Debug.Log(Fcode);

        switch (gameManager.gameState)
        {
            case GameState.InGame0:
                if (Fcode == "1,0,0,0")
                {
                    ResetCode();
                    gameManager.gameState = GameState.InGame1;
                }
                break;
            case GameState.InGame1:
                if (Fcode == "0,1,0,0")
                {
                    ResetCode();
                    gameManager.gameState = GameState.InGame2;
                }
                break;
            case GameState.InGame2:
                if (Fcode == "0,0,1,0")
                {
                    ResetCode();
                    gameManager.gameState = GameState.InGameAll;

                }
                break;
            default:
                ResetCode();
                break;
            
        }
    }

    public void ResetCode()
    {
        for (int i = 0; i < CodeText.Length; i++)
        {
            CodeText[i].text = 0.ToString();
            CodeHolder[i] = 0;
        }
        currentLoc = 0;
    }
}

    