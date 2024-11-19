using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool IsDown;
    public GameObject Lever;
    public GameObject GameManagerHolder;
    private bool HasPassed = false;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManagerHolder.GetComponent<GameManager>();
    }
    void Update()
    {
        if (!IsDown && Lever.transform.rotation.eulerAngles.x < 40)
        {
            IsDown = true;
        }

        if (IsDown && !HasPassed)
        {
            gameManager.gameState = GameState.InGame0;
            HasPassed = true;
        }
    }
}
