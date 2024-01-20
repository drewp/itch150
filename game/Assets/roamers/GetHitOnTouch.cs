using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitOnTouch : MonoBehaviour{
    void Update()
    {
        var player = transform.position;
        foreach (var r in GameObject.Find("roamers").GetComponent<RoamerSpawn>().RoamersNear(player, 1f))
        {
            r.GetComponent<RoamerWalk>().JumpAwayFrom(player);
        }
    }
}

