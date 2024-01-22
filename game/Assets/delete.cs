using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    public int time = 15000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
