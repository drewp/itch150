using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ingredient : MonoBehaviour
{
    public string name;
    public float value;
    [SerializeField]
    private inventory inventory;
    private GameObject playerObj;
    private Transform player;
    private Vector3 scaleChange;
    [SerializeField]
    private float scaleamount = 1.0f;
    SpriteRenderer sr;
    [SerializeField]
    bool isStarter = false;

    private void Start()
    {
        if (!isStarter) { value = Random.Range(0f, 2.0f); }
        
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(0.2f + value/2.5f, 0.2f + value / 2.5f, 0.2f + value / 2.5f, 1.0f);
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
        inventory = player.GetComponent<inventory>();
        scaleChange = new Vector3(+scaleamount, +scaleamount, -0.0f);
    }


    void Update()
    {


        float distance = Vector2.Distance(player.position, gameObject.transform.position);

        if (distance < 1.0f)
        {

            if (Input.GetKeyDown("e"))
            {
                inventory.add(name, value);
                Destroy(gameObject);
                
            }

        }
        
    }
}
