using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public static float health = 300;
    void Start()
    {
        health = 300;   
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        LightMeter L = new LightMeter();
        if(L.LightIntensityAtPoint(transform.position) >= 0.5f)
        {
            health += 0.001f;
        }
    }

}












































































































































//Hi :)
