using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        // testing
        var m = Instantiate(prefab, transform);
        m.transform.position = new Vector2(-6, -4);
    }

    void Update()
    {

    }
}
