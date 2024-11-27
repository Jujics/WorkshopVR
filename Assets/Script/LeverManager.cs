using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public AudioSource ActivateSound;
    public AudioSource BruitSound;
    public bool IsDown;
    public GameObject Lever;
    public GameObject GameManagerHolder;
    public GameObject Activation;
    public Material ActivatedMaterial;
    public Light Blicklight;
    private bool CorutineRunning = false;
    private bool HasPassed = false;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManagerHolder.GetComponent<GameManager>();
    }
    void Update()
    {
        if (!IsDown)
        {
            if (!CorutineRunning)
            {
                StartCoroutine(LightBlink());
            }
        }
        
        if (!IsDown && Lever.transform.rotation.eulerAngles.x < 40)
        {
            IsDown = true;
            Activation.GetComponent<MeshRenderer> ().material = ActivatedMaterial;
            ActivateSound.Play ();
            BruitSound.Play ();
        }

        if (IsDown && !HasPassed)
        {
            gameManager.gameState = GameState.InGame0;
            HasPassed = true;
        }

        if (IsDown)
        {
           Blicklight.enabled = true;
        }
    }

    IEnumerator LightBlink()
    {
        CorutineRunning = true;
    
        while (true) 
        {
            Blicklight.enabled = true;
            yield return new WaitForSeconds(1f); 

            Blicklight.enabled = false;
            yield return new WaitForSeconds(1f); 
            
            break;
        }

        CorutineRunning = false; 
    }
    
    

}
