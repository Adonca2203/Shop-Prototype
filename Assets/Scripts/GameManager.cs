using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic Game Manager to manage game states
/// </summary>
public class GameManager : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public enum GameState
    {
        play,
        shop,
        inventory
    }

    public GameState currentState = GameState.play;

}
