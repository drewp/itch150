using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_destroy : MonoBehaviour
{
    [SerializeField]
    float Damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Roamer")
        {
            Debug.Log("HIT ROAMER");
            collision.gameObject.GetComponent<RoamerManager>().Health -= (int)Damage;
            Destroy(this.gameObject);
        }
    }
}
