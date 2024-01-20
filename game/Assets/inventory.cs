using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    
    public float Flower = 0f, Meat = 0f, Root = 0f;

    
    public void add(string name, float value)
    {
        if (name == "flower" && Flower == 0)
        {
            Flower= value;
            Debug.Log(Flower);

        }
        if (name == "meat" && Meat == 0)
        {
            Meat = value;
            Debug.Log(Flower);

        }
        if (name == "root" && Root == 0)
        {
            Root = value;
            Debug.Log(Flower);

        }
    }

}
