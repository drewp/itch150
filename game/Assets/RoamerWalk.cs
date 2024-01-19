using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerWalk : MonoBehaviour
{
    public float angle;
    public float lastAnglePickTime = 0.0f;

    void Start()
    {

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        if (GetComponent<RoamerAnim>().IsDead)
        {
            return;
        }
        var now = Time.time;
        if (now > lastAnglePickTime + 1)
        {
            lastAnglePickTime = now;
            angle = PickDirection();
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.Translate(Vector2.up * 0.1f * Time.fixedDeltaTime);
    }

    float PickDirection()
    {
        var angleDegrees = Mathf.Lerp(0, 360, Random.value);
        return angleDegrees;
    }
}
