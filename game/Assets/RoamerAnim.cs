using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerAnim : MonoBehaviour
{
    public bool IsDead = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var aliveSprite = GetComponent<SpriteRenderer>();
        var deadSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            aliveSprite.color = new Color(1f, 1f, 1f, IsDead ? 0f : 1f);
            deadSprite.color = new Color(1f, 1f, 1f, IsDead ? 1f : 0f);
    }
}
