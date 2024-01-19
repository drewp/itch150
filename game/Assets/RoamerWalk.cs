using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerWalk : MonoBehaviour
{
    public Vector3 goalPos;
    public bool goalPosSet = false;
    public float lastGoalTime = 0.0f;
    public float playerAffinity = 0.1f; // 0 = random walk; 1 = always head for player
    private float closeToPlayerThreshold = 2f;
    private float randId;
    void Start()
    {
        randId = Random.value;
    }

    void Update()
    {
        GetComponent<RoamerAnim>().Face(goalPos.x > transform.position.x);
        Debug.DrawLine(transform.position, goalPos);
    }

    void FixedUpdate()
    {
        if (GetComponent<RoamerAnim>().IsDead)
        {
            return;
        }

        var dist = Vector2.Distance(goalPos, transform.position);
        if (!goalPosSet || dist < .1)
        {
            goalPosSet = true;
            PickNewGoal();
        }
        var gallopSpeed = 0.5f + 0.8f * Math.Abs(Mathf.Sin(Time.time * 3 + randId * 5));
        transform.position = Vector2.MoveTowards(transform.position, goalPos, gallopSpeed * Time.fixedDeltaTime);
    }

    private void PickNewGoal()
    {
        var offset = new Vector3(Random.value - .5f, Random.value - .5f, 0) * 2 * 3;
        var rand = transform.position + offset;
        var player = GameObject.FindWithTag("Player").transform.position;
        var distToPlayer = Vector2.Distance(player, transform.position);
        if (distToPlayer < closeToPlayerThreshold)
        {
            goalPos = player;
        }
        else
        {
            goalPos = Vector2.Lerp(rand, player, playerAffinity);
        }
    }
}
