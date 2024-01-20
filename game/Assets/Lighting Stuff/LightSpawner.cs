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
    public static void SpawnLight(float size, Transform transform, GameObject Hole)
    {
        GameObject Obj = Instantiate(Hole, transform.position, transform.rotation) as GameObject;
        Obj.transform.localScale = new Vector3(size, size, 1);
    }
}
