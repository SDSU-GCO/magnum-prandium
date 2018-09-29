using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSupervisor : MonoBehaviour {

    public static GameSupervisor gameSupervisor = null;
    public static GameObject globalDataObject = null;
    [SerializeField]
    string defaultLevel = "";
    
    private void Awake()
    {
        Debug.Assert(gameSupervisor == null, "There should only be one game manager in the game!, found: " + gameSupervisor + " Expected: null");
        gameSupervisor = this;
    }
    private void OnDestroy()
    {
        Debug.Assert(gameSupervisor == this, "There should only be one game manager in the game!, found: " + gameSupervisor + " Expected: "+this );
        gameSupervisor = null;
    }

    //game initial load instructions
    private void Start()
    {
        globalDataObject = GameObject.Find("GameData");

        //start game
        Debug.Assert(defaultLevel != "", "Error: No default scene is selected!");
        SceneSwitcher.switchScene(defaultLevel);
    }
}
