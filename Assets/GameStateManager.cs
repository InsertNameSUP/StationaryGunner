using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Paused,
        Shop
    };
    public static GameState currentGameState { get; private set; }
    
    public static void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
    }
}
