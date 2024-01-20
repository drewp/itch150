using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
            pos.z = -1;
            SpawnLight(3.8f, pos, Hole, 0.5f, 3.4f);
        }
    }
    public static void SpawnLight(float size, Transform transform, GameObject Hole)
    {
        GameObject Obj = Instantiate(Hole, transform.position, transform.rotation) as GameObject;
        Obj.transform.localScale = new Vector3(size, size, 1);
    }
    public static void SpawnLight(float size, Vector3 pos, GameObject Hole, float InnerRad, float OuterRad)
    {
        GameObject Obj = Instantiate(Hole, pos, Quaternion.identity);
        Obj.transform.localScale = new Vector3(size, size, 1);
        Obj.GetComponentInChildren<Light2D>().pointLightInnerRadius = InnerRad;
        Obj.GetComponentInChildren<Light2D>().pointLightOuterRadius = OuterRad;
    }
}
