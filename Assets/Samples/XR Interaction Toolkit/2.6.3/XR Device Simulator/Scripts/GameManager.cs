using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null!");
            }
            return _instance;
        }
    }

    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;

    public bool HasCard { get; set; }

    private void Update()
    {
        

    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        UpdateGameState(GameState.GameStart);
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState; 
        switch (gameState)
        {
            case GameState.GameStart:
            {
                HandleGameStart();
                break;
            }
            case GameState.InGame0:
            {
                HandleInGame0();
                break;
            }
            case GameState.InGame1:
            {
                HandleInGame1();
                break;
            }
            case GameState.InGame2:
            {
                HandleInGame2();
                break;
            }
            case GameState.InGameAll:
            {
                HandleInGameAll();
                break;
            }
            case GameState.Win:
            {
                HandleWin();
                break;
            }
            case GameState.Pause:
            {
                HandlePause();
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleInGameAll()
    {
        throw new NotImplementedException();
    }

    private void HandleInGame2()
    {
        throw new NotImplementedException();
    }

    private void HandleInGame1()
    {
        throw new NotImplementedException();
    }

    private void HandleInGame0()
    {
        throw new NotImplementedException();
    }

    private void HandleGameStart()
    {
        Debug.Log("Game Start");
    }

    private void HandleWin()
    {
        // Logic for winning the game
    }

    private void HandleLose()
    {
        // Logic for losing the game
    }

    private void HandlePause()
    {
        // Logic For Game Pause
    }
}

public enum GameState
{
    GameStart,
    InGame0,
    InGame1,
    InGame2,
    InGameAll,
    Win,
    Pause
}