using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public static float health = 300;
    public static bool HasKey;
    [SerializeField]
    Image hpbar;
    void Start()
    {
        HasKey = false;
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
        hpbar.fillAmount= health/3f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Our Lord And Saviour Jesus Christ Bless His Holy Name")
        {
            HasKey = true;
        }
        if(collision.gameObject.tag == "Door" && HasKey == true)
        {
            //transport to boss scene
        }
        Destroy(this.gameObject);
    }
}












































































































































//Hi :)
