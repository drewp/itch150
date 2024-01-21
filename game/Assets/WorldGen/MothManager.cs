using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothManager : MonoBehaviour
{
    public static float Count;
    public static float ToNextMoth;
    public static float NextMulti;

    public GameObject Moth;
    void Start()
    {
        Count = 0;
        ToNextMoth = 40;
        NextMulti = 1.1f;
    }
    void Update()
    {
        if(Count >= ToNextMoth)
        {
            ToNextMoth *= NextMulti;
        }
    }
    void SpawnMoth()
    {

    }
}
