using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillRoamerOnTouch : MonoBehaviour
{
    void Update()
    {
        var player = transform.position;
        foreach (var r in GameObject.Find("roamers").GetComponent<RoamerSpawn>().RoamersNear(player, 1f))
        {
            r.GetComponent<RoamerAnim>().Die(10f);
        }
    }
}
