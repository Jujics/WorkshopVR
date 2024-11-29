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
    public bool HasEnteredCode3 = false;
    public AudioSource InteractDigiAudio;
    public AudioSource CodeFauxAudio;
    public AudioSource CodeBonAudio;
    public GameObject Card;
    private bool HasEnteredCode1 = false;
    private bool HasEnteredCode2 = false;
    
    
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
        InteractDigiAudio.Play();
    }

    public void OnValidateButton()
    {
        InteractDigiAudio.Play();
        string Fcode = string.Join(',', CodeHolder);
        Debug.Log(Fcode);
        
        if (HasEnteredCode2 && HasEnteredCode1)
        {
            if (Fcode == "2,1,8,1")
            {
                Card.SetActive(true);
                //setactive(canvas) = False
                HasEnteredCode3 = true;
                CodeBonAudio.Play();
                Card.SetActive(true);
                ResetCode();
            }
        }
        
        if (HasEnteredCode1)
        {
            if (Fcode == "2,1,5,7")
            {
                //Setactive(image1) = false
                //Setactive(image2) = true
                HasEnteredCode2 = true;
                CodeBonAudio.Play();
                ResetCode();
            }
        }
        
        if (!HasEnteredCode1)
        {
            if (Fcode == "2,1,5,4")
            {
                //Setactive(image0) = false
                //Setactive(image1) = true
                HasEnteredCode1 = true;
                CodeBonAudio.Play();
                ResetCode();
            }
        }
        else
        {
            CodeFauxAudio.Play(); 
            ResetCode();
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

    