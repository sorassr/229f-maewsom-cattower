using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
