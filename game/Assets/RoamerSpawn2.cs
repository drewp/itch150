using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn2 : MonoBehaviour
{
    public GameObject Roamer;
    public int RoamerCount = 0;
    public float DifficultyMod = 1;
    public int MaxRoamers = 10;
    public float DeadRoamers = 1;
    void Start()
    {
        SpawnMore(transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((int)Random.Range(1, (100 * (RoamerCount)) / (DifficultyMod+(DeadRoamers/100))) == 10)
        {
            SpawnMore(transform);
        }
        DifficultyMod += 0.0001f;
        if(MaxRoamers/(DifficultyMod*10) >= 1)
        {
            MaxRoamers += 1;
        }
    }
    public void SpawnMore(Transform transform)
    {
        if (RoamerCount <= MaxRoamers)
        {
            Instantiate(Roamer, new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10), 1), transform.rotation);
            RoamerCount++;
        }
    }
}
