using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kindling : MonoBehaviour
{
    public float kindle = 1.0f;
    [SerializeField]
    private Image kindlebar;
    public void burn(float amount)
    {
        Debug.Log("ticked");
        kindle -= amount;
        kindlebar.fillAmount = kindle;
    }
    
}
