using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Rendering.Universal;
public class LightMeter : MonoBehaviour
{

    public bool debugLightField = false;
    public void Update()
    {
        if (debugLightField)
        {
            DrawDebugLightField();
        }
    }

    void DrawDebugLightField()
    {
        for (var x = -8f; x < 8f; x += .6f)
        {
            for (var y = -8f; y < 8f; y += .6f)
            {
                var p = new Vector2(x, y);
                var v = LightIntensityAtPoint(p);
                Debug.DrawLine(p, p + new Vector2(0, v * .1f));

            }
        }
    }

    public float LightIntensityAtPoint(Vector2 pos)
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();
        float totalBrightness = 0f;
        foreach (Light2D light in lights)
        {
            float distance = Vector2.Distance(pos, light.transform.position);
            totalBrightness += light.intensity * Mathf.InverseLerp(light.pointLightOuterRadius, light.pointLightInnerRadius, distance);
        }
        return totalBrightness;
    }
}
