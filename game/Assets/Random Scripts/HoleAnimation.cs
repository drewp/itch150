using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HoleAnimation : MonoBehaviour
{
    private float birthTime;
    private float noiseOffset;
    private AnimationClip clip;
    private GameObject childLight;
    void Start()
    {
        birthTime = Time.time;
        noiseOffset = Random.Range(0f,10f);
        clip = Resources.Load<AnimationClip>("HoleFadeIn");
        childLight = transform.Find("Light").gameObject;
    }

    void Update()
    {
        float now = Time.time;
        var age = now - birthTime;
        if (age < clip.length)
        {
            clip.SampleAnimation(childLight, age);
        }
        else
        {
            childLight.GetComponent<Light2D>().intensity = 4 + 2 * Mathf.PerlinNoise(now * 3 + noiseOffset, 0f);
        }

    }
}
