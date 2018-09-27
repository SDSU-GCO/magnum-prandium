using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeyWimeyGameController : MonoBehaviour {

    public float timeMultiplier = 0.5f;
    public float effectDuration = 2.0f;
    public float fadeIn = 0;
    public float fadeOut = 1;
    
    bool slowed = false;
    Coroutine slowTime = null;
    float originalTimeScale;
    float originalFixedDeltaTime;
    
    public void triggerSlowMo()
    {
        if(slowed && slowTime!=null)
        {
            StopCoroutine(slowTime);
            Time.timeScale = originalTimeScale;
            Time.fixedDeltaTime = originalFixedDeltaTime;
        }
        originalTimeScale = Time.timeScale;
        originalFixedDeltaTime = Time.fixedDeltaTime;
        slowTime = StartCoroutine(triggerSlowMo(effectDuration, timeMultiplier, fadeIn, fadeOut));
    }

    IEnumerator triggerSlowMo(float effectDuration, float timeMultiplier, float fadeIn, float fadeOut)
    {
        slowed = true;
        float originalTimeScale = Time.timeScale;
        float originalFixedDeltaTime = Time.fixedDeltaTime;
        float currentDuration = 0;
        float fadeInCompletedTime = effectDuration * fadeIn;
        float fadeOutStartTime = effectDuration - (effectDuration * fadeOut);
        Debug.Assert(timeMultiplier != 0, "Error: SlowMo timeMultiplier can not be (0) in: "+this);
        float currentTimeScale = timeMultiplier;
        float currentFixedDeltaTime = (1.0f/60.0f) * (1.0f/timeMultiplier);
        Debug.Assert(fadeIn >= 0 && fadeIn <= 1, "Error: SlowMo fade in is out of bounds(0-1) in: " + this);
        Debug.Assert(fadeOut >= 0 && fadeOut <= 1, "Error: SlowMo fade out is out of bounds(0-1) in: " + this);
        Debug.Assert((fadeIn + fadeOut) <= 1, "Error: fadeIn(" + fadeIn + ") + fadeOut(" + fadeOut + ") should be <= 1.0 in: " + this);

        float timeDifference = 1.0f - timeMultiplier;
        if (timeDifference != 0)
        {
            while (currentDuration < effectDuration)
            {
                if (currentDuration <= fadeInCompletedTime && fadeInCompletedTime != 0)
                {
                    currentTimeScale = timeMultiplier + (timeDifference * (currentDuration / fadeInCompletedTime));
                    currentFixedDeltaTime = (1.0f / 60.0f) * (timeMultiplier + (timeDifference * (currentDuration / fadeInCompletedTime)));
                }
                else if (currentDuration >= fadeOutStartTime && fadeOutStartTime != effectDuration)
                {
                    currentTimeScale = timeMultiplier + (timeDifference * (((currentDuration - fadeOutStartTime) / (effectDuration - fadeOutStartTime))));
                    currentFixedDeltaTime = (1.0f / 60.0f) * (timeMultiplier + (timeDifference * ((currentDuration - fadeOutStartTime) / (effectDuration - fadeOutStartTime))));
                }
                else
                {
                    currentTimeScale = timeMultiplier;
                    currentFixedDeltaTime = (1.0f / 60.0f) * timeMultiplier;
                }
                Time.timeScale = currentTimeScale;
                Time.fixedDeltaTime = currentFixedDeltaTime;
                currentDuration = Mathf.Min(effectDuration, currentDuration + Time.unscaledDeltaTime);
                yield return null;
            }
        }
        slowed = false;
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = originalFixedDeltaTime;
    }
}
