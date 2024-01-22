using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthStack : MonoBehaviour
{
    void Update()
    {
        var yNorm = Mathf.InverseLerp(-50, 50, transform.position.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, yNorm);
    }
}
