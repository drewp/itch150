using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerManager : MonoBehaviour
{
    public float Health = 1.0f;
    public GameObject Hole;
    public bool CantDie;
    float Damage = 10;
    public int Type = 0;

    public GameObject BlueMeat;
    public GameObject Kindle;
    [SerializeField]
    PlayManager PlayManager;

    AudioSource Sfx;

    public void SetStats(int health, int type, float speed, float size, float viewdistance, float lighttolerance, float playerAffinity, float closeThresh, float damage)
    {
        RoamerWalk Ai = gameObject.GetComponent<RoamerWalk>();
        gameObject.transform.localScale = new Vector3(size, size, 1);
        Health = health;
        Type = type;
        Ai.loSpeed = speed - (speed / 3);
        Ai.hiSpeed = speed;
        Ai.playerAffinity = playerAffinity;
        Ai.closeToPlayerThreshold = closeThresh;
        Ai.maxPlayerSpottingDistance = viewdistance;
        Ai.intoLight = lighttolerance;
        Damage = damage;
    }
    private void Start()
    {
        PlayManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayManager>();
        Sfx = GetComponent<AudioSource>();
    }

    public void SetStats(int health)
    {
        Health = health;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            //Health = 0;
        }
        if (Health <= 0 && !CantDie)
        {
            if(Random.Range(1, 10) == 1)
            {
                Instantiate(BlueMeat, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            }
            switch (Type)
            {
                case 0:
                    RoamerSpawn2.ElapsedMultiplier += 0.03f;
                    LightSpawn.SpawnLight(7f, transform.position, Hole, 0.5f, 3.4f);
                    MothManager.Count += 1;
                    break;
                case 1:
                    RoamerSpawn2.ElapsedMultiplier += 0.02f;
                    LightSpawn.SpawnLight(6f, transform.position, Hole, 0.3f, 3.5f);
                    MothManager.Count += 1;
                    break;
                case 2:
                    RoamerSpawn2.ElapsedMultiplier += 0.14f;
                    LightSpawn.SpawnLight(14f, transform.position, Hole, 1.2f, 5.6f);
                    MothManager.Count += 2;
                    break;
                case 3:
                    LightSpawn.SpawnLight(20f, transform.position, Hole, 2.5f, 7.9f);
                    RoamerSpawn2.ElapsedMultiplier += 0.3f;
                    MothManager.Count += 2;
                    break;
            }
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if(Random.Range(1, 400) == 1)
        {
            Sfx.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayManager.takeDamage(20f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * 5000);
        }
    }
}
