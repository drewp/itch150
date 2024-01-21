using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_destroy : MonoBehaviour
{
    [SerializeField]
    private inventory inventory;
    public float Damage;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Roamer")
        {
            collision.gameObject.GetComponent<RoamerManager>().Health -= (int)Damage*(int)inventory.Flower;
            Destroy(this.gameObject);
        }
    }
}
