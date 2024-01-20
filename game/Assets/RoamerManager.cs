using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerManager : MonoBehaviour
{
    public int Health;
    void RoamerInit(int health)
    {
        Health = health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            RoamerSpawn2.DifficultyMod += 0.03f;
            RoamerSpawn2.RoamerCount--;
            Destroy(this);
        }
    }
}
