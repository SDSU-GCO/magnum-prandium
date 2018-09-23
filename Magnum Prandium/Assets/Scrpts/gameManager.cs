using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;

    private void Awake()
    {
        Debug.Assert(gameManager == null, "There should only be one game manager in the game!, found: " + gameManager + " Expected: null");
        gameManager = this;
    }
    private void OnDestroy()
    {
        Debug.Assert(gameManager == this, "There should only be one game manager in the game!, found: " + gameManager + " Expected: "+this );
        gameManager = null;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
