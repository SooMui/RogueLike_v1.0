using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        Game.Health = HP.initialHealth;
        SceneManager.LoadScene(4);
        
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
