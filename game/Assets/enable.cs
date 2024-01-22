using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable : MonoBehaviour
{
    // Start is called before the first frame update
    public bool del;
    public int minus = 2500;
    void Start()
    {
        
    }
    public void Enable()
    {
        del = true;
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(del == true)
        {
            minus--;
        }
        if(minus <= 0)
        {
            Destroy(gameObject);
        }
    }
}
