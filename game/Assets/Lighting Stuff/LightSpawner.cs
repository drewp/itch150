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
            SpawnLight(7f, pos, Hole, 0.5f, 3.4f);
        }
    }
    public static void SpawnLight(float size, Vector3 pos, GameObject Hole, float InnerRad, float OuterRad)
    {
        LightMeter meter = FindAnyObjectByType<LightMeter>();
        if(meter.LightIntensityAtPoint(pos) < 0.5f)
        {
            GameObject[] Flow = GameObject.FindGameObjectsWithTag("Flower");
            for (int i = 0; i < Flow.Length; i++)
            {
                if (Vector2.Distance(Flow[i].transform.position, pos) <= 2)
                {
                    Debug.Log(Vector2.Distance(Flow[i].transform.position, pos));
                    //SpriteRenderer d = Hole.transform.Find("Rendering").GetComponent<SpriteRenderer>();
                    //d.size = new Vector3(0, 0, 0);
                    return;
                }
            }
            GameObject Obj = Instantiate(Hole, pos, Quaternion.identity);
            Obj.transform.localScale = new Vector3(size, size, 1);
            Obj.GetComponentInChildren<Light2D>().pointLightInnerRadius = InnerRad;
            Obj.GetComponentInChildren<Light2D>().pointLightOuterRadius = OuterRad;
        }
    }
}
