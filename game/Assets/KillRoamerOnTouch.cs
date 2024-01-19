using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillRoamerOnTouch : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var player = transform.position;
        foreach (var r in GameObject.Find("roamers").GetComponent<RoamerSpawn>().RoamersNear(player, 1f))
        {
            r.GetComponent<RoamerAnim>().Die(10f);
        }
    }
}
