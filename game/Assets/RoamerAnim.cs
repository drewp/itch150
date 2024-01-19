using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class RoamerAnim : MonoBehaviour
{
    public float DeathTime = -1.0f;  // -1 means alive
    public float DarkTime = 0.0f;
    private SpriteRenderer aliveSprite;
    private SpriteRenderer deadSprite;
    public void Awake()
    {
        DeathTime = -1f;
    }
    void Start()
    {
        aliveSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        deadSprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }
    public bool IsAlive()
    {
        return DeathTime < 0f;
    }
    public void Face(bool right)
    {
        aliveSprite.flipX = !right;
    }
    public void Die(float fadeTime)
    {
        DeathTime = Time.time;
        DarkTime = DeathTime + fadeTime;
    }
    void Update()
    {
        aliveSprite.color = new Color(1f, 1f, 1f, IsAlive() ? 1f : 0f);
        deadSprite.color = new Color(1f, 1f, 1f, !IsAlive() ? DeadOpacity() : 0f);
    }

    private float DeadOpacity()
    {
        return 1f - Mathf.InverseLerp(DeathTime, DarkTime, Time.time);
    }
}
