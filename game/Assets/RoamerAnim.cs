using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerAnim : MonoBehaviour
{
    public bool IsDead = false;
    public float DeathTime = 0.0f;
    public float DarkTime = 0.0f;
    void Start()
    {

    }
    public void Die()
    {
        IsDead = true;
        DeathTime = Time.time;

        DarkTime = DeathTime + Mathf.Lerp(5, 8, Random.value);
    }
    void Update()
    {
        var aliveSprite = GetComponent<SpriteRenderer>();
        var deadSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        aliveSprite.color = new Color(1f, 1f, 1f, IsDead ? 0f : 1f);
        deadSprite.color = new Color(1f, 1f, 1f, IsDead ? (1f - Mathf.InverseLerp(DeathTime, DarkTime, Time.time)) : 0f);

    }
}
