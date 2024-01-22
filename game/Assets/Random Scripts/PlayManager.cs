using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public float health = 300;
    public static bool HasKey;
    [SerializeField]
    Image hpbar;
    void Start()
    {
        if(this.health != 300)
        {
            health = 300;
        }
        HasKey = false;
        health = 300;   
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DeathScreen");

        }
    }
    public void takeDamage(float dmg)
    {
        health -= dmg;
        hpbar.fillAmount = health / 300f;

    }
    private void FixedUpdate()
    {
        LightMeter meter = FindAnyObjectByType<LightMeter>();
        if(meter.LightIntensityAtPoint(transform.position) >= 0.5f)
        {
            health += 0.001f;
        }
        hpbar.fillAmount= health/300f;
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("TestWorld");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key (For You Ari)")
        {
            HasKey = true;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Door" && HasKey == true)
        {
            SceneManager.LoadScene("TestWorld");
        }
        
    }
}












































































































































//Hi :)
