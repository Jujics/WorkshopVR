using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    public GameObject gameManagerHolder;
    GameManager gameManager;

    void Start()
    {
        gameManager = gameManagerHolder.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            gameManager.gameState = GameState.Win;
        }
    }
}
