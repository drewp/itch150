using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamerManager : MonoBehaviour
{
    public int Health = 1;
    public GameObject Hole;
    public bool CantDie;
    int damage = 10;
    void Start()
    {
        
    }
    void Update()
    {
        if(Health <= 0 && CantDie == false)
        {
            RoamerSpawn2.DifficultyMod += 0.03f;
            RoamerSpawn2.RoamerCount--;
            LightSpawn.SpawnLight(3.8f, transform, Hole);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("W");
            PlayManager.health -= damage;
            gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * 5000);
        }
    }
}
