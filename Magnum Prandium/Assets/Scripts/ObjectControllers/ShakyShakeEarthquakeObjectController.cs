using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyShakeEarthquakeObjectController : MonoBehaviour {

    [SerializeField]
    public float duration=1;
    [SerializeField]
    public float magnitudePos=1;
    [SerializeField]
    public float magnitudeRot=1;
    [SerializeField]
    public float fadeIn=0.25f;
    [SerializeField]
    public float fadeOut=0.25f;
    
    
    private struct Transformation
    {
        public Vector2 vector2;
        public float rotation;
    }

    private void Start()
    {
        ShakeyShakeEarthquakeSceneSupervisor.shakeyShakeEarthquakeSceneSupervisor.RockTheBoat += rockTheBoat;
        ShakeyShakeEarthquakeSceneSupervisor.shakeyShakeEarthquakeSceneSupervisor.RockTheBoatRelative += rockTheBoat;
    }

    private List<Transformation> transformations = new List<Transformation>();

    public void rockTheBoat()
    {
        StartCoroutine(ShakeObject2D(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut));
    }

    public void rockTheBoat(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut)
    {
        StartCoroutine(ShakeObject2D(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut));
    }

    public void rockTheBoat(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut, Transform transform)
    {
        magnitudePos /= Vector2.Distance(transform.position, this.transform.position);
        magnitudeRot /= Vector2.Distance(transform.position, this.transform.position);
        float delayFactor = 10;
        float delay = Vector2.Distance(transform.position, this.transform.position) / delayFactor;

        StartCoroutine(ShakeObject2D(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut, delay));
    }

    public void Update()
    {
        foreach(Transformation transformation in transformations)
        {
            transform.position = new Vector2(transform.position.x - transformation.vector2.x, transform.position.y - transformation.vector2.y);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.z - transformation.rotation);
        }
        transformations.Clear();
    }

    IEnumerator ShakeObject2D(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut, float delay=0)
    {
        float delayEnd = Time.time + delay;
        while(delayEnd>Time.time)
        {
            yield return null;
        }

        float currentDuration = 0;
        float fadeInCompletedTime = duration * fadeIn;
        float fadeOutStartTime = duration - (duration * fadeOut);

        float currentMagnitudePos=0;
        float currentMagnitudeRot=0;

        Debug.Assert(fadeIn >= 0 && fadeIn <= 1, "Error, shake fade in is out of bounds(0-1) in: " + this);
        Debug.Assert(fadeOut >= 0 && fadeOut <= 1, "Error, shake fade out is out of bounds(0-1) in: " + this);
        Debug.Assert((fadeIn + fadeOut) <= 1, "Error, fadeIn(" + fadeIn + ") + fadeOut(" + fadeOut + ") should be <= 1.0 in: " + this);
        
        while (currentDuration < duration)
        {
            currentDuration = Mathf.Min(duration, currentDuration + Time.deltaTime);
            if(currentDuration<=fadeInCompletedTime && fadeInCompletedTime != 0)
            {
                currentMagnitudePos = magnitudePos * (currentDuration / fadeInCompletedTime);
                currentMagnitudeRot = magnitudeRot * (currentDuration / fadeInCompletedTime);
            }
            else if(currentDuration>=fadeOutStartTime && fadeOutStartTime != duration)
            {
                currentMagnitudePos = magnitudePos * (1 + ((fadeOutStartTime-currentDuration) / (duration - fadeOutStartTime)));
                currentMagnitudeRot = magnitudeRot * (1 + ((fadeOutStartTime-currentDuration) / (duration - fadeOutStartTime)));
            }
            else
            {
                currentMagnitudePos = magnitudePos;
                currentMagnitudeRot = magnitudeRot;
            }
            
            Vector2 tempVector = new Vector2((Random.Range(-currentMagnitudePos, currentMagnitudePos)), (Random.Range(-currentMagnitudePos, currentMagnitudePos)));
            Transformation transformation = new Transformation();
            transformation.vector2 = tempVector;
            transformation.rotation = (Random.Range(-currentMagnitudeRot, currentMagnitudeRot));
            transform.position = new Vector2(transform.position.x + tempVector.x, transform.position.y + tempVector.y);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.z + transformation.rotation);
            transformations.Add(transformation);
            
            yield return null;
        }
    }
}
