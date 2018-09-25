using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController gameController = null;
    public static GameObject globalDataObject = null;
    [SerializeField]
    string defaultLevel = "";
    
    private void Awake()
    {
        Debug.Assert(gameController == null, "There should only be one game manager in the game!, found: " + gameController + " Expected: null");
        gameController = this;
    }
    private void OnDestroy()
    {
        Debug.Assert(gameController == this, "There should only be one game manager in the game!, found: " + gameController + " Expected: "+this );
        gameController = null;
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
