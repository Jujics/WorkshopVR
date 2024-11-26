using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Testaudio : MonoBehaviour
{
    public AudioSource CliqueBouton;

    public void SoundClique()
    {
        CliqueBouton.Play();
    }
}
