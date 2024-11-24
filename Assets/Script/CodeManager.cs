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
    private bool HasEnteredCode1 = false;
    private bool HasEnteredCode2 = false;
    private bool HasEnteredCode3 = false;
    public bool HasEnteredCode4 = false;
    private bool[] State = { false, false, false, false };


    GameManager gameManager;
    

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
        if (HasEnteredCode2 && HasEnteredCode1 && HasEnteredCode3)
        {
            if (Fcode == "0,0,0,0")
            {
                HasEnteredCode4 = true;
                ResetCode();
            }
        }
        
        if (HasEnteredCode2 && HasEnteredCode1)
        {
            if (Fcode == "0,0,0,0")
            {
                HasEnteredCode3 = true;
                ResetCode();
            }
        }
        
        if (HasEnteredCode1)
        {
            if (Fcode == "0,0,0,0")
            {
                HasEnteredCode2 = true;
                ResetCode();
            }
        }
        
        if (!HasEnteredCode1)
        {
            if (Fcode == "0,0,0,0")
            {
                HasEnteredCode1 = true;
                ResetCode();
            }
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

    