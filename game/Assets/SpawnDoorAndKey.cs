using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorAndKey : MonoBehaviour
{
    public GameObject Door;
    public GameObject Key;
    void Start()
    {
        int DoorSide = Random.Range(1, 2);
        if(DoorSide == 1)
        {
            Instantiate(Door, new Vector3(Random.Range(70, 110), Random.Range(30, 50) - 1), Quaternion.identity);
            Instantiate(Key, new Vector3(Random.Range(-70, -110), Random.Range(-30, -50) - 1), Quaternion.identity);
        } else
        {
            Instantiate(Key, new Vector3(Random.Range(70, 110), Random.Range(30, 50) - 1), Quaternion.identity);
            Instantiate(Door, new Vector3(Random.Range(-70, -110), Random.Range(-30, -50) - 1), Quaternion.identity);
        }
    }
    void Update()
    {
        
    }
}
