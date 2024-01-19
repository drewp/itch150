using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerSpawn : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        var m = Instantiate(prefab, transform);
        m.transform.position = new Vector2(-6, -4);
        m.GetComponent<RoamerAnim>().IsDead = false;

        SpawnCorpse(new Vector2(-3, -2));
        SpawnCorpse(new Vector2(1, -1));
        SpawnCorpse(new Vector2(4, -3));
    }

    GameObject SpawnCorpse(Vector2 pos)
    {
        var m = Instantiate(prefab, transform);
        m.transform.position = pos;
        m.GetComponent<RoamerAnim>().IsDead = true;
        return m;
    }

    void Update()
    {

    }
}
