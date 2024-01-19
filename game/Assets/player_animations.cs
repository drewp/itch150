using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animations : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Animator anm;
    [SerializeField]
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (rigidBody.velocity.x > 0)
        {
            sr.flipX = true;
            anm.SetBool("isWalking", true);
            anm.SetBool("isIdle", false);
        }
        else if (rigidBody.velocity.x < 0)
        {

            sr.flipX = false;
            anm.SetBool("isWalking", true);
            anm.SetBool("isIdle", false);
            
        }
        else if (rigidBody.velocity.magnitude == 0)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", true);
        }
    }
}
