using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayNightObserver : MonoBehaviour
{
    public abstract void OnTimeChanged(float timeRatio);
}