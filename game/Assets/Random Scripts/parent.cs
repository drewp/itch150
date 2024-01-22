using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player");
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
