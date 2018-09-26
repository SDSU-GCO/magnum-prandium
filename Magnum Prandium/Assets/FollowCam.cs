using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject cameraDollyTarget = null;

    private void Start()
    {
        if(cameraDollyTarget==null)
        {
            Debug.LogWarning("cameraDollyTarget in "+this+" is not wet, attempting to default to object tagged (protagonist)");
            cameraDollyTarget = GameObject.FindGameObjectWithTag("Protagonist");
        }
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(cameraDollyTarget.transform.position.x, cameraDollyTarget.transform.position.y, cameraDollyTarget.transform.position.z - 10);
	}
}
