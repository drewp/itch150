using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoamerSpawn : MonoBehaviour
{
    public GameObject prefab;
    public bool spawnDeadCircle = true;
    public bool spawnAliveCircle = true;
    public int minSpawned = 10;
    private int counter = 0;
    void Start()
    {
        if (spawnAliveCircle)
        {
            for (var i = 0.0f; i < 6.28; i += 0.4f)
            {
                var m = Make(new Vector2(8 * Mathf.Sin(i),
                8 * Mathf.Cos(i)));
            }
        }
        if (spawnDeadCircle)
        {
            for (var i = 0.0f; i < 6.28; i += 0.4f)
            {
                SpawnCorpse(new Vector2(4 * Mathf.Sin(i),
                                        4 * Mathf.Cos(i)));
            }
            SpawnCorpse(new Vector2(1, -1));
            SpawnCorpse(new Vector2(4, -3));
        }
    }

    GameObject SpawnCorpse(Vector2 pos)
    {
        var m = Make(pos);
        m.GetComponentInChildren<RoamerAnim>().Die(Mathf.Lerp(5, 20, Random.value));
        return m;
    }

    GameObject Make(Vector3 pos)
    {
        var m = Instantiate(prefab, transform);
        m.name = "spawnedRoamer" + counter;
        m.transform.position = pos;
        counter++;
        return m;

    }

    public void FixedUpdate()
    {
        var now = Time.time;
        DestroyExpiredRoamers(now);
        SpawnMore();
    }

    private void DestroyExpiredRoamers(float now)
    {
        var toKill = new List<GameObject>();
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var anim = child.GetComponent<RoamerAnim>();
            if (!anim.IsAlive() && now > anim.DarkTime)
            {
                toKill.Add(child.gameObject);
            }
        }
        foreach (var r in toKill)
        {
            Destroy(r);
        }
    }

    private void SpawnMore()
    {
        if (transform.childCount < minSpawned)
        {
            var m = Make(new Vector3(10f, (Random.value - .5f) * 4f, 0f));
        }
    }

    public List<GameObject> RoamersNear(Vector2 pos, float maxDistance = 1f)
    {
        var ret = new List<GameObject>();
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (Vector2.Distance(child.transform.position, pos) < maxDistance) ret.Add(child);

        }
        return ret;
    }
}
