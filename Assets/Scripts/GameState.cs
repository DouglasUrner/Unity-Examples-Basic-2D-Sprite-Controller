using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    // Game state variables that need to persist between levels.
    private static int _sceneNumber = 0;
    private static Transform _playerTransform;

    // Setters & getters to provide access to state variables.
    public static int SceneNumber
    {
        get { return _sceneNumber; }
        set { _sceneNumber = value; }
    }

    // Pass the player's position between scenes.
    public static Transform PlayerTransform {
        get;
        set;
    }
}
