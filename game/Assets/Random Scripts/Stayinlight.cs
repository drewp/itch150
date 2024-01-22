using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stayinlight : MonoBehaviour
{
    LightMeter meter;
    int count;
    PlayManager pm;
    bool ticking = false;
    [SerializeField]
    TMP_Text warn;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayManager>();
        meter = FindAnyObjectByType<LightMeter>();
        warn.enabled = false;
    }
    void tick()
    {
        Debug.Log(meter.LightIntensityAtPoint(transform.position));
        Debug.Log("h");
        if (count > 0f)
        {
            pm.takeDamage(20);
        }
        if (meter.LightIntensityAtPoint(transform.position) <= 0.1f)
        {
            Invoke("tick", 1f);

            count++;
        }
        else
        {
            count = 0;
            Debug.Log(meter.LightIntensityAtPoint(transform.position));
            ticking = false;
            warn.enabled = false;
            return;
        }

        
        
    }
    private void Update()
    {
        
        if (meter.LightIntensityAtPoint(transform.position) <= 0.1f && !ticking)
        {
            warn.enabled = true;

            tick();
            ticking = true;
        }
    }

}
