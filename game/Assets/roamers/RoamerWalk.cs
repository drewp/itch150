using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerWalk : MonoBehaviour
{
    public Vector3 goalPos;
    public float playerAffinity = 0.1f; // 0 = random walk; 1 = always head for player
    public float goalDistance = 2f; // approx max size of a goal step
    public float closeToPlayerThreshold = 2f; // closer than this; just aim for player
    public float maxPlayerSpottingDistance = 10f; // closer than this; aim for player *if you can see them*
    public float maxTimeOnOneGoal = 3f;

    public float loSpeed = 1f;
    public float hiSpeed = 4f;

    private float nextGoalUpdateTime = 0.0f;
    private float randId;
    private float curSpeed;

    void Start()
    {
        randId = Random.value;
    }

    void Update()
    {
        GetComponent<RoamerAnim>().Face(goalPos.x > transform.position.x);

        if (GetComponent<RoamerAnim>().IsAlive())
        {
            Debug.DrawLine(transform.position, goalPos);
        }
    }

    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody2D>();

        if (!GetComponent<RoamerAnim>().IsAlive())
        {
            rb.simulated = false;
            return;
        }

        var now = Time.time;
        var dist = Vector2.Distance(goalPos, transform.position);

        if (now > nextGoalUpdateTime || dist < .1)
        {
            nextGoalUpdateTime = now + maxTimeOnOneGoal * (.7f + .6f * randId);
            goalPos = PickNewGoal();
        }
        var gallopSpeed = 0.5f + 0.8f * Math.Abs(Mathf.Sin(Time.time * 3 + randId * 5));
        rb.velocity = (goalPos - transform.position).normalized * curSpeed;
    }

    private Vector3 PickNewGoal()
    {
        var ret = transform.position;
        var tries = 10;
        while (tries-- > 0)
        {
            var offset = new Vector3(Random.value - .5f, Random.value - .5f, 0) * 2 * goalDistance;
            var rand = transform.position + offset;
            GameObject player = GameObject.FindWithTag("Player");
            var playerPos = player.transform.position;
            var distToPlayer = Vector2.Distance(playerPos, transform.position);
            if (distToPlayer < closeToPlayerThreshold || (distToPlayer < maxPlayerSpottingDistance && LineOfSightToPlayer(player)))
            {
                ret = playerPos;
                curSpeed = hiSpeed;
            }
            else
            {
                ret = Vector2.Lerp(rand, playerPos, playerAffinity);
                curSpeed = loSpeed;
            }
            if (GameObject.Find("roamers").GetComponent<LightMeter>().LightIntensityAtPoint(ret) > .5f)
            {
                continue;
            }
            break;
        }
        return ret;
    }

    private bool LineOfSightToPlayer(GameObject player)
    {
        var playerPos = player.transform.position;
        var myCollider = GetComponent<CircleCollider2D>();
        RaycastHit2D[] results = new RaycastHit2D[1];
        myCollider.Cast(playerPos - transform.position, results);
        if (results[0].collider != null && results[0].collider.tag == "Player")
        {
            Debug.DrawLine(transform.position, playerPos);
            return true;
        }
        return false;
    }
}
