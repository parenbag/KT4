using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : DayNightObserver
{
    public Transform sunTransform;
    public float sunRadius = 5f;

    public override void OnTimeChanged(float timeRatio)
    {
        float angle = Mathf.Lerp(0, 360, timeRatio);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * sunRadius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * sunRadius;
        sunTransform.position = new Vector3(x, y, 0);
    }
}