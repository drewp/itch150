using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerSpawn : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        for (var i = 0.0f; i < 6.28; i += 0.4f)
        {
            var m = Instantiate(prefab, transform);
            m.transform.position = new Vector2(8 * Mathf.Sin(i),
            8 * Mathf.Cos(i));
        }

        SpawnCorpse(new Vector2(-3, -2));
        SpawnCorpse(new Vector2(1, -1));
        SpawnCorpse(new Vector2(4, -3));
    }

    GameObject SpawnCorpse(Vector2 pos)
    {
        var m = Instantiate(prefab, transform);
        m.transform.position = pos;
        m.GetComponentInChildren<RoamerAnim>().Die(Mathf.Lerp(5, 8, Random.value));
        return m;
    }

}
