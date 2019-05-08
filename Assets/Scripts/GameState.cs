using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** When loading a new scene, Unity destroys all of the game objects in
** the old scene. Information that needs to persist between scenes has
** to be "stashed" somewhere before loading the new scene and then
** recovered before it is used again in the new scene. That is the purpose
** of the GameState class.
*/

public static class GameState
{
    /*
     * Game state variables that need to persist between levels.
     */
    private static int _sceneNumber = 0;
    private static Transform _playerTransform;

    /*
     * Setters & getters to provide access to state variables.
     */

    // Index of the currently loaded scene.
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
