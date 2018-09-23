using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    
    private void Start()
    {
        Debug.Assert(SceneLogic.sceneData == null, "There should only be one scene data in the scene!, found: " + SceneLogic.sceneData + " Expected: null");
        SceneLogic.sceneData = gameObject;
    }

    private void OnDestroy()
    {
        Debug.Assert(SceneLogic.sceneData == gameObject, "There should only be one scene data in the scene!, found: " + SceneLogic.sceneData + " Expected: " + gameObject);
        SceneLogic.sceneData = gameObject;
    }
}
