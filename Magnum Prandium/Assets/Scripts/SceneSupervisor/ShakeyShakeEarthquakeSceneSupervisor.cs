using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeyShakeEarthquakeSceneSupervisor : MonoBehaviour {

    static ShakeyShakeEarthquakeSceneSupervisor shakeyShakeEarthquakeSceneSupervisor = null;
    public delegate void rockTheBoatDelegate(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut);
    public delegate void rockTheBoatRelativeDelegate(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut, Transform transform);

    public event rockTheBoatDelegate RockTheBoat;
    public event rockTheBoatRelativeDelegate RockTheBoatRelative;

    public static void implode(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut)
    {
        shakeyShakeEarthquakeSceneSupervisor.RockTheBoat.Invoke(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut);
    }

    public static void implode(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut, Transform transform)
    {
        shakeyShakeEarthquakeSceneSupervisor.RockTheBoatRelative.Invoke(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut, transform);
    }

    private void Awake()
    {
        Debug.Assert(shakeyShakeEarthquakeSceneSupervisor == null, "Error: ShakeyShakeEarthquakeSceneSupervisor(" + shakeyShakeEarthquakeSceneSupervisor + ") is not null in "+this);
        shakeyShakeEarthquakeSceneSupervisor = this;
    }

    private void OnDestroy()
    {
        Debug.Assert(shakeyShakeEarthquakeSceneSupervisor == this, "Error: ShakeyShakeEarthquakeSceneSupervisor(" + shakeyShakeEarthquakeSceneSupervisor + ") is not equal to: " + this);
        if(shakeyShakeEarthquakeSceneSupervisor==this)
            shakeyShakeEarthquakeSceneSupervisor = null;
    }
    
}
