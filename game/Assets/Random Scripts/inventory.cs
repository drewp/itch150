using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    
    private float Flower, Meat, Root = 0f;

    
    public void add(string name, float value)
    {
        if (name == "flower" && Flower == 0)
        {
            Flower= value;
            Debug.Log(Flower);

        }
    }

}
