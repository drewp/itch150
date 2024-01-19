using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    [SerializeField]
    private int time = 20;
    int tick = 0;

    void Start()
    {
        _tick();
    }
    private void _tick()
    {
        
        tick++;
        if (tick<20)
        {
           
            Invoke("_tick", 1f);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}