using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn2 : MonoBehaviour
{
    public GameObject Roamer;
    public static int RoamerCount = 0;
    public static float DifficultyMod = 1;
    public int MaxRoamers = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RoamerCount == 0)
        {
            SpawnMore(transform);
        }
        if ((int)Random.Range(1, (100 * (RoamerCount)) / (DifficultyMod)) == 10)
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
            GameObject Object = Instantiate(Roamer, new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10), -1), transform.rotation);
            Object.GetComponent<RoamerManager>().Health = (int)(100 * (DifficultyMod / 2));
            RoamerCount++;
        }
    }
}
