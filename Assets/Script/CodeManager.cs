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
}
