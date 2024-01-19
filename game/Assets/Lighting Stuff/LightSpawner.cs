using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawn : MonoBehaviour
{
    public GameObject Hole;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -11;
            Instantiate(Hole, pos, transform.rotation);
        }
    }
}
