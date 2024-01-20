using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerManager : MonoBehaviour
{
    public int Health;
    public GameObject Hole;
    void Start()
    {
        
    }
    void Update()
    {
        if(Health <= 0)
        {
            RoamerSpawn2.DifficultyMod += 0.03f;
            RoamerSpawn2.RoamerCount--;
            LightSpawn.SpawnLight(3.8f, transform, Hole);
            Destroy(this.gameObject);
        }
    }
}
