using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothPathManager : MonoBehaviour
{
    float speed = 10;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity += new  Vector2(10, 10);
    }
}
