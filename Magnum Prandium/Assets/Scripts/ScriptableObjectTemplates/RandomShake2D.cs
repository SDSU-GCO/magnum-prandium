using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RandomShake2D : SignalSourceAsset
{
    public float shakeMagnitudePosx = 0.1f;
    public float shakeMagnitudePosy = 0.1f;
    public float shakeMagnitudeRot = 0.1f;

    public override float SignalDuration
    {
        get
        {
            return 1;
        }
    }

    public override void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        rot = Quaternion.Euler(0, 0, Random.Range(-shakeMagnitudeRot, shakeMagnitudeRot));
        pos = new Vector3(Random.Range(-shakeMagnitudePosx, shakeMagnitudePosx), Random.Range(-shakeMagnitudePosy, shakeMagnitudePosy), 0);
    }
    
}
