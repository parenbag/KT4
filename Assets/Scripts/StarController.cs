using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : DayNightObserver
{
    public SpriteRenderer starRenderer;

    public override void OnTimeChanged(float timeRatio)
    {
        float alpha = 0f;
        if (timeRatio < 0.25f || timeRatio >= 0.75f)
        {
            alpha = 1f;
        }
        else if (timeRatio < 0.3f)
        {
            alpha = Mathf.Lerp(1f, 0f, (timeRatio - 0.25f) / 0.05f);
        }
        else if (timeRatio >= 0.7f)
        {
            alpha = Mathf.Lerp(0f, 1f, (timeRatio - 0.7f) / 0.05f);
        }

        Color color = starRenderer.color;
        color.a = alpha;
        starRenderer.color = color;
    }
}