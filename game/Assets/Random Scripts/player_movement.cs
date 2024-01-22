using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Line
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float runSpeed = 10.0f;
    AudioSource Sfx;
    // Start is called before the first frame update
    void Start()
    {
        Sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized* runSpeed;
        if(rigidBody.velocity.x >= 0.3f || rigidBody.velocity.y >=0.3f)
        {
            Debug.Log("yes");
            Sfx.Play();
        } else
        {
            Sfx.Stop();
        }
    }
}
