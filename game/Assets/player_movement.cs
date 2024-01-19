using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Line
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float runSpeed = 3000.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * runSpeed;
    }
}
