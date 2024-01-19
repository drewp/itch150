using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerWalk : MonoBehaviour
{
    public Vector3 goalPos;
    public float lastAnglePickTime = -999.0f;
    public float playerAffinity = 0.7f; // 0 = random walk; 1 = always head for player
    private float closeToPlayerThreshold=2.0f;

    void Start()
    {

    }

    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = goalPos.x < transform.position.x;
        Debug.DrawLine(transform.position, goalPos);
    }
    void FixedUpdate()
    {
        if (GetComponent<RoamerAnim>().IsDead)
        {
            return;
        }

        var now = Time.time;
        if (now > lastAnglePickTime + Random.Range(2,3))
        {
            lastAnglePickTime = now;
            var rand = transform.position + (Vector3)Random.insideUnitCircle.normalized * 2;
            var player = GameObject.FindWithTag("Player").transform.position;
            if (Vector2.Distance(player, transform.position) < closeToPlayerThreshold)
            {
                goalPos = player;
            }
            else
            {
                goalPos = Vector2.Lerp(rand, player, playerAffinity);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPos, 0.5f * Time.fixedDeltaTime);
    }

    float PickDirection()
    {
        var angleDegrees = Mathf.Lerp(0, 360, Random.value);
        return angleDegrees;
    }
}
