using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kindling : MonoBehaviour
{
    public static float kindle = 2.5f;
    [SerializeField]
    private Image kindlebar;
    public void burn(float amount)
    {
        kindle -= amount;
        kindlebar.fillAmount = kindle;
    }
    
}