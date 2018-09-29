using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigObjectController : MonoBehaviour {

    public static CameraRigObjectController cameraRigObjectController = null;

    private void Awake()
    {
        Debug.Assert(cameraRigObjectController==null, "CameraRigObjectController("+cameraRigObjectController+") is not null "+this);
        cameraRigObjectController = this;
    }

    private void OnDestroy()
    {
        Debug.Assert(cameraRigObjectController == this, "CameraRigObjectController(" + cameraRigObjectController + ") is not " + this);
        cameraRigObjectController = null;
    }
}
