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
    public GameObject Key;
    public GameObject Door;
    public GameObject Text;
    [SerializeField]
    Image hpbar;
    bool first = false;
    void Start()
    {
        if(this.health != 300)
        {
            health = 300;
        }
        HasKey = false;
        health = 300;
        Key = GameObject.FindWithTag("Key (For You Ari)");
        Door = GameObject.FindWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestWorld" && first == false)
        {
            first = true;
            transform.position = new Vector3(0, 0, -1);
        }
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
        Debug.Log("hi");
        
        LightMeter meter = FindAnyObjectByType<LightMeter>();
        if(meter.LightIntensityAtPoint(transform.position) >= 0f)
        {
            takeDamage(-0.05f);
        }
        hpbar.fillAmount= health/300f;
        
        if (health > 300)
        {
            health = 300;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key (For You Ari)")
        {
            HasKey = true;
            Destroy(collision.gameObject);
            Debug.Log("Ys");
            Text.GetComponent<enable>().Enable();
        }
        if(collision.gameObject.tag == "Door" && HasKey == true)
        {
            SceneManager.LoadScene("TestWorld");
        }
        
    }
}












































































































































//Hi :)
