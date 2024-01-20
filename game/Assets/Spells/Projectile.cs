using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public float Damage;
    public float TellDespawn;
    public float Speed;
    public Vector2 CircularMove = new Vector2(0, 0);
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (CircularMove.x == 0 && CircularMove.y == 0)
        {
            Rigid.AddForce(transform.right * Speed);
        } else
        {
            Rigid.velocity = new Vector2(CircularMove.x, CircularMove.y);
        }
        TellDespawn--;
        if(TellDespawn <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Roamer")
        {
            collision.gameObject.GetComponent<RoamerManager>().Health -= (int)Damage;
            Destroy(this.gameObject);
        }
    }
}
