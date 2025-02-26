using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public float dayDuration = 120f; // Длительность суток в секундах
    public Color morningSkyColor;
    public Color daySkyColor;
    public Color eveningSkyColor;
    public Color nightSkyColor;

    private float currentTime = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > dayDuration)
        {
            currentTime = 0f;
        }

        float timeRatio = currentTime / dayDuration;
        UpdateSkyColor(timeRatio);
        NotifyObservers(timeRatio);
    }

    void UpdateSkyColor(float timeRatio)
    {
        if (timeRatio < 0.25f)
        {
            mainCamera.backgroundColor = Color.Lerp(nightSkyColor, morningSkyColor, timeRatio / 0.25f);
        }
        else if (timeRatio < 0.5f)
        {
            mainCamera.backgroundColor = Color.Lerp(morningSkyColor, daySkyColor, (timeRatio - 0.25f) / 0.25f);
        }
        else if (timeRatio < 0.75f)
        {
            mainCamera.backgroundColor = Color.Lerp(daySkyColor, eveningSkyColor, (timeRatio - 0.5f) / 0.25f);
        }
        else
        {
            mainCamera.backgroundColor = Color.Lerp(eveningSkyColor, nightSkyColor, (timeRatio - 0.75f) / 0.25f);
        }
    }

    void NotifyObservers(float timeRatio)
    {
        foreach (var observer in FindObjectsOfType<DayNightObserver>())
        {
            observer.OnTimeChanged(timeRatio);
        }
    }
}