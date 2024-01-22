using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deathscreen : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("RealWorld");
    }
    public void Menu()
    {
        Debug.Log("to the main menu");
    }
}