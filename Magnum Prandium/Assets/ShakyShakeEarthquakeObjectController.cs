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

    Coroutine thisObjectsLastShake = null;
    bool shaking = false;
    
    Vector3 originalPosition;
    Quaternion originalRotation;

    public void rockTheBoat()
    {
        if (shaking == true && thisObjectsLastShake !=null)
        {
            StopCoroutine(thisObjectsLastShake);
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
            shaking = false;
        }
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
        thisObjectsLastShake = StartCoroutine(ShakeObject2D(duration, magnitudePos, magnitudeRot, fadeIn, fadeOut));
    }

    IEnumerator ShakeObject2D(float duration, float magnitudePos, float magnitudeRot, float fadeIn, float fadeOut)
    {
        shaking = true;
        Vector3 originalPosition = transform.localPosition;
        Quaternion originalRotation = transform.localRotation;
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
                currentMagnitudePos = magnitudePos * (1 - ((currentDuration - fadeOutStartTime) / (duration - fadeOutStartTime)));
                currentMagnitudeRot = magnitudeRot * (1 - ((currentDuration - fadeOutStartTime) / (duration - fadeOutStartTime)));
            }
            else
            {
                currentMagnitudePos = magnitudePos;
                currentMagnitudeRot = magnitudeRot;
            }
            transform.localPosition = new Vector2(originalPosition.x + (Random.Range(-currentMagnitudePos, currentMagnitudePos)), originalPosition.y + (Random.Range(-currentMagnitudePos, currentMagnitudePos)));
            transform.localRotation= Quaternion.Euler(originalRotation.eulerAngles.x, originalRotation.y, originalRotation.z + (Random.Range(-currentMagnitudeRot, currentMagnitudeRot)));
            
            yield return null;
        }

        shaking = false;
        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
    }
}
