using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    // Game state variables that need to persist between levels.
    private static int _sceneNumber = 0;

    // Setters & getters to provide access to state variables.
    public static int SceneNumber
    {
        get { return _sceneNumber; }
        set { _sceneNumber = value; }
    }
}
