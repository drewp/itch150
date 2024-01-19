using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        for (var i = 0.0f; i < 6.28; i += 0.4f)
        {
            SpawnCorpse(new Vector2(4 * Mathf.Sin(i),
                                    4 * Mathf.Cos(i)));
        }
        SpawnCorpse(new Vector2(1, -1));
        SpawnCorpse(new Vector2(4, -3));
    }

    GameObject SpawnCorpse(Vector2 pos)
    {
        var m = Instantiate(prefab, transform);
        m.transform.position = pos;
        m.GetComponentInChildren<RoamerAnim>().Die(Mathf.Lerp(5, 20, Random.value));
        return m;
    }

    public void Update()
    {

        for (var x = -8f; x < 8f; x += .6f)
        {
            for (var y = -8f; y < 8f; y += .6f)
            {
                var p = new Vector2(x, y);
                var v = LightIntensityAtPoint(p);
                Debug.DrawLine(p, p + new Vector2(0, v * .1f));

            }
        }
    }
    public void FixedUpdate()
    {
        var now = Time.time;
        DestroyExpiredRoamers(now);
        if (transform.childCount < 10)
        {
            var m = Instantiate(prefab, transform);
            m.transform.position = new Vector3(-6, -6, 0);
        }
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

    public float LightIntensityAtPoint(Vector2 pos)
    {
        var total = 0.0f;
        for (var i = 0; i < transform.childCount; i++)
        {
            var r = transform.GetChild(i);
            if (r.GetComponent<RoamerAnim>().IsAlive()) { continue; }
            var dist = Vector2.Distance(r.transform.position, pos);
            var noLightPastDistance = 3f;
            var fullLightUpToDistance = 1f;
            total += Mathf.InverseLerp(noLightPastDistance, fullLightUpToDistance, dist);
        }
        return total;
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
