using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoamerAnim : MonoBehaviour
{
    public bool IsDead = false;
    public float DeathTime = 0.0f;
    public float DarkTime = 0.0f;
    private SpriteRenderer aliveSprite;
    private SpriteRenderer deadSprite;
    void Start()
    {
        aliveSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        deadSprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }
    public void Face(bool right)
    {
        aliveSprite.flipX = !right;
    }
    public void Die(float fadeTime)
    {
        IsDead = true;
        DeathTime = Time.time;
        DarkTime = DeathTime + fadeTime;
    }
    void Update()
    {
        aliveSprite.color = new Color(1f, 1f, 1f, IsDead ? 0f : 1f);
        deadSprite.color = new Color(1f, 1f, 1f, IsDead ? (1f - Mathf.InverseLerp(DeathTime, DarkTime, Time.time)) : 0f);
    }
}
