using System;
using System.Collections;
using System.Collections.Generic;
using LevelUP.Dial;
using UnityEngine;

public class DialEnigma : Enigma
{
    public DialStruct[] Dials;
    public BoxOpening boxOpening;
    private bool Completed = false;
    
    void Start()
    {
        OnComplete.AddListener(() => boxOpening.BoxOpened = true);
        foreach (var dial in Dials)
        {
            dial.Dial.onChanged = (s) => { CheckCompleted(); };
        }
        Launch();
    }
    
    public void CheckCompleted()
    {
        foreach (var dial in Dials)
        {
            if (dial.Dial.Value != dial.Solution)
            {
                return;
            }
            Completed = true;
        }
    }
    
    public override IEnumerator WaitForEnigmaCompletion()
    {
        yield return new WaitUntil(() => Completed);
        OnComplete.Invoke();
    }
}

[Serializable]
public struct DialStruct
{
    public DialRotationDisplay Dial;
    public string Solution;
}