using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public delegate void StateChange();
    public static event StateChange OnGameStateChange;
    public enum GameState
    {
        Playing,
        Paused,
        Shop
    };
    private GameState currentGameState;
    public static GameStateManager instance;
    private void Awake()
    {
        instance = this;
    }
    public static void SetGameState(GameState newGameState)
    {
        instance.currentGameState = newGameState;
        if (OnGameStateChange != null) OnGameStateChange();
    }
    public static GameState GetGameState()
    {
        return instance.currentGameState;
    }
}
