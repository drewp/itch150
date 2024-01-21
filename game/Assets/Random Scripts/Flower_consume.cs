using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_consume : MonoBehaviour
{
    [SerializeField]
    kindling kindling;
    [SerializeField]
    GameObject parent;
    
    void Start()
    {
        kindling = GameObject.FindGameObjectWithTag("Player").GetComponent<kindling>();

    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            kindling.burn(-50);
            Destroy(parent);
        }
        
    }
}
