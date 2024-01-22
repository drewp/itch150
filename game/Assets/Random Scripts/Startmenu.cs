using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startmenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("RealWorld");
    }
    public void Quit()
    {
        Application.Quit();
    }
}