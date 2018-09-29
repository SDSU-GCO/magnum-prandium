using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyTaggerObjectController : MonoBehaviour {

    List<GameObject> preyList = null;

    // Use this for initialization
    private void Awake()
    {
        if(preyList==null)
        {
            Debug.Assert(SceneSupervisor.sceneData != null, "Error: reference to sceneData in SceneController is null!");
            preyList = SceneSupervisor.sceneData.GetComponent<PreyData>().preyList;
            Debug.Assert(preyList != null, "Error: reference to preyList in \"" + this + "\" is null!");
            preyList.Add(gameObject);
        }
    }
    private void OnEnable()
    {
        if (preyList == null)
        {
            Debug.Assert(SceneSupervisor.sceneData != null, "Error: reference to sceneData in SceneController is null!");
            preyList = SceneSupervisor.sceneData.GetComponent<PreyData>().preyList;
            Debug.Assert(preyList != null, "Error: reference to preyList in \"" + this + "\" is null!");
            preyList.Add(gameObject);
        }
    }

    private void OnDisable()
    {
        if (preyList != null && preyList.Contains(gameObject))
        {
            preyList.Remove(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(preyList!= null && preyList.Contains(gameObject))
        {
            preyList.Remove(gameObject);
        }
    }
}
