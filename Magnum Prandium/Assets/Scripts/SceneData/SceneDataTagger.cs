using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataTagger : MonoBehaviour {
    
    private void Awake()
    {
        Debug.Assert(SceneSupervisor.sceneData == null, "There should only be one scene data in the scene!, found: " + SceneSupervisor.sceneData + " Expected: null");
        SceneSupervisor.sceneData = gameObject;
    }

    private void OnDestroy()
    {
        Debug.Assert(SceneSupervisor.sceneData == gameObject, "There should only be one scene data in the scene!, found: " + SceneSupervisor.sceneData + " Expected: " + gameObject);
        if(SceneSupervisor.sceneData==gameObject)
        {
            SceneSupervisor.sceneData = null;
        }
    }
}
