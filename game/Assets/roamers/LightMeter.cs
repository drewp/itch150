using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightMeter : MonoBehaviour
{

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

    public float LightIntensityAtPoint(Vector2 pos)
    {
        var total = 0.0f;

        foreach (Glow glowComponent in FindObjectsOfType<Glow>())
        {
            // redo as brightness
            if (glowComponent.TryGetComponent<RoamerAnim>(out RoamerAnim anim))
            {
                if (anim.IsAlive()) { 
                    continue; 
                }
            }

            var dist = Vector2.Distance(glowComponent.transform.position, pos);
            total += Mathf.InverseLerp(glowComponent.darkRadius, glowComponent.brightRadius, dist);
        }
        return total;
    }
}
