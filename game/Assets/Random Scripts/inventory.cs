using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    
    public float Flower = 0f, Meat = 0f, Root = 0f;
    [SerializeField]
    private Image flowericon, rooticon, meaticon;
    
    public void add(string name, float value)
    {
        if (name == "flower" && Flower == 0f)
        {
            flowericon.enabled = true;
            Flower= value;
            Debug.Log(Flower);

        }
        if (name == "meat" && Meat == 0f)
        {
            meaticon.enabled = true;
            Meat = value;
            Debug.Log(Flower);

        }
        if (name == "root" && Root == 0f)
        {
            rooticon.enabled = true;
            Root = value;
            Debug.Log(Flower);

        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        { 
            Flower = Root = Meat = 0;
            flowericon.enabled = rooticon.enabled = meaticon.enabled = false;


        }
    }

}
