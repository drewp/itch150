using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaMana : MonoBehaviour
{
    int Expire = 1000;
    private void FixedUpdate()
    {
        Expire--;
        if(Expire == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
