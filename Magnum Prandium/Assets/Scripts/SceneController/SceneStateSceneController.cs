using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateSceneController : MonoBehaviour
{
    PlayerData playerData = null;
    EnemyData enemyData = null;
    
    public void Start()
    {
        playerData = GameController.globalDataObject.GetComponent<PlayerData>();
        Debug.Assert(playerData != null, "Error in " + this + " the playerData is null!");
        enemyData = SceneController.sceneData.GetComponent<EnemyData>();
        Debug.Assert(enemyData != null, "Error in " + this + " the enemyData is null!");
    }

    public enum SceneState { GAME_OVER, VICTORY, PLAYING, ERROR }
    [SerializeField]
    SceneState sceneStateBackingField = SceneState.PLAYING;
    public SceneState sceneState
    {
        get
        {
            return sceneStateBackingField;
        }
        set
        {
            if (sceneStateBackingField != value)
            {
                handleSceneStateChange(sceneStateBackingField, value);
                sceneStateBackingField = value;
            }
        }
    }

    private void handleSceneStateChange(SceneState oldState, SceneState newState)
    {
        cleanOldState(oldState);
        setNewState(newState);
    }

    private void setNewState(SceneState newState)
    {
        switch (newState)
        {
            case SceneState.GAME_OVER:
                {
                    Debug.Log("Player ded");
                    break;
                }
            case SceneState.VICTORY:
                {
                    Debug.Log("Congrats on killing all the badies!  You win!");
                    break;
                }
            case SceneState.PLAYING:
                {
                    Debug.Log("Switching to play state...");
                    break;
                }
            case SceneState.ERROR:
                {
                    Debug.LogError("Ummm... I have no idea how you got here...  Error in switch for SceneStateSceneController newstate setter...");
                    break;
                }

        }
    }

    private void cleanOldState(SceneState oldState)
    {
        switch (oldState)
        {
            case SceneState.GAME_OVER:
                {
                    Debug.Log("Player no longer ded");
                    break;
                }
            case SceneState.VICTORY:
                {
                    Debug.Log("Uh oh, the badies are coming back! ;)");
                    break;
                }
            case SceneState.PLAYING:
                {
                    Debug.Log("Leaving play state, bye bye.");
                    break;
                }
            case SceneState.ERROR:
                {
                    Debug.LogError("Ummm... I have no idea how you got here...  Leaving error in switch for SceneStateSceneController oldstate cleaner...");
                    break;
                }

        }
    }

    private void Update()
    {
        if (playerData.HP <= 0)
        {
            sceneState = SceneState.GAME_OVER;
        }
        else if (enemyData.enemyCount <= 0)
        {
            sceneState = SceneState.VICTORY;
        }
    }
}
