using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_destroy : MonoBehaviour
{
    [SerializeField]
    float Damage;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Roamer")
        {
            collision.gameObject.GetComponent<RoamerManager>().Health -= (int)Damage;
            Destroy(this.gameObject);
        }
    }
}
