using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public int health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Debug.Log("You Died");
        }
    }
}
