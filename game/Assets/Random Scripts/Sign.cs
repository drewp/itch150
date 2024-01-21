using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class Sign : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    private GameObject playerObj;
    private Transform player;
    [SerializeField]
    string msg;
    [SerializeField]
    Image panel;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, gameObject.transform.position);

        if (distance < 1.0f)
        {

            if (Input.GetKeyDown("e"))
            {
                
                text.enabled = true;
                panel.enabled = true;
                text.text = msg;

            }

        }
        if (distance > 1.0f) 
        {
            text.enabled = false;
            panel.enabled = false;
        }
    }
}
