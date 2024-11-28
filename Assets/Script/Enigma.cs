using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Enigma : MonoBehaviour
{
    public UnityEvent OnComplete;
    public UnityEvent OnFail;

    public void Launch() => StartCoroutine(WaitForEnigmaCompletion());

    public abstract IEnumerator WaitForEnigmaCompletion();
}