using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public static int health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
          //  Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
        }
    }
}