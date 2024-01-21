using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kindling : MonoBehaviour
{
    public static float kindle = 1.0f;
    [SerializeField]
    private Image kindlebar;
    private void Start()
    {
        kindle = 1.0f;
    }
    public void burn(float amount)
    {
        kindle -= amount;
        kindlebar.fillAmount = kindle;
    }
    
}
