using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnable;
    [SerializeField]
    private float width = 40f;
    [SerializeField]
    private float height = 40f;
    [SerializeField]
    private int min = 3;
    [SerializeField]
    private int max = 15;
    // Start is called before the first frame update
    void Start()
    {
        int amount = Random.Range(min, max);
        for (int i = 0; i < amount; i++)
        {
            float xcord = Random.Range(-width, width);
            float ycord = Random.Range(-height, height);
            Instantiate(spawnable, new Vector3(xcord, ycord, 0), Quaternion.identity);
        }
    }
    
    
}
