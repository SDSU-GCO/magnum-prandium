using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakyShakeEarthquakeCameraObjectController : MonoBehaviour {

    public static ShakyShakeEarthquakeCameraObjectController shakyShakeEarthquakeCameraObjectController = null;
    public bool ignoreDelay = false;

    private void Awake()
    {
        shakyShakeEarthquakeCameraObjectController = this;
    }
    private void OnDestroy()
    {
        if(shakyShakeEarthquakeCameraObjectController==this)
        {
            shakyShakeEarthquakeCameraObjectController = null;
        }
    }

    public float duration = 1;
    public float magnitude = 1;
    public float fadeIn = 0.25f;
    public float fadeOut = 0.25f;
    public float delayFactor = 4;

    public void rockTheBoat()
    {
        CinemachineImpulseSource tempSource = GetComponent<CinemachineImpulseSource>();
        CinemachineImpulseDefinition tempDef = tempSource.m_ImpulseDefinition;
        tempDef.m_AmplitudeGain = magnitude;
        tempDef.m_TimeEnvelope.m_AttackTime = duration * fadeIn;
        tempDef.m_TimeEnvelope.m_DecayTime = duration * fadeOut;
        tempDef.m_TimeEnvelope.m_SustainTime = duration - ((duration * fadeOut) + (duration * fadeIn));

        tempSource.GenerateImpulse();
    }

    public void rockTheBoat(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut)
    {
        CinemachineImpulseSource tempSource = GetComponent<CinemachineImpulseSource>();
        CinemachineImpulseDefinition tempDef = tempSource.m_ImpulseDefinition;
        tempDef.m_AmplitudeGain = (magnitudePos + magnitudeRot) / 2.0f;
        tempDef.m_TimeEnvelope.m_AttackTime = duration*fadeIn;
        tempDef.m_TimeEnvelope.m_DecayTime = duration * fadeOut;
        tempDef.m_TimeEnvelope.m_SustainTime = duration - ((duration*fadeOut)+(duration*fadeIn));
         
        tempSource.GenerateImpulse();
    }

    public void rockTheBoat(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut, Transform transform)
    {
        magnitudePos /= Vector2.Distance(transform.position, this.transform.position);
        magnitudeRot /= Vector2.Distance(transform.position, this.transform.position);
        float delay = Vector2.Distance(transform.position, this.transform.position) / delayFactor;

        CinemachineImpulseSource cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        CinemachineImpulseDefinition tempDef = cinemachineImpulseSource.m_ImpulseDefinition;
        tempDef.m_AmplitudeGain = (magnitudePos + magnitudeRot) / 2.0f;
        tempDef.m_TimeEnvelope.m_AttackTime = duration * fadeIn;
        tempDef.m_TimeEnvelope.m_DecayTime = duration * fadeOut;
        tempDef.m_TimeEnvelope.m_SustainTime = duration - ((duration * fadeOut) + (duration * fadeIn));

        StartCoroutine(delayShake(cinemachineImpulseSource, delay));
    }

    IEnumerator delayShake(CinemachineImpulseSource cinemachineImpulseSource, float delayInSeconds)
    {
        if(ignoreDelay!=true)
        {
            float waitUntilThisTime = delayInSeconds + Time.time;
            while (Time.time < waitUntilThisTime)
            {
                yield return null;
            }
        }

        cinemachineImpulseSource.GenerateImpulse();
    }

    private void Start()
    {
        ShakeyShakeEarthquakeSceneSupervisor shakeyShakeEarthquakeSceneSupervisor = SceneSupervisor.sceneSupervisor.GetComponent<ShakeyShakeEarthquakeSceneSupervisor>();
        shakeyShakeEarthquakeSceneSupervisor.RockTheBoat += rockTheBoat;
        shakeyShakeEarthquakeSceneSupervisor.RockTheBoatRelative += rockTheBoat;
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            rockTheBoat();
        }
    }
}
