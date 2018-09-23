using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {


    private void Awake()
    {
        Debug.Assert(sceneLogic == null, "There should only be one scene logic in the scene!, found: " + sceneLogic + " Expected: null");
        sceneLogic = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
