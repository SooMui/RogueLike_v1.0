using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    private bool isPaused = false;

    void Start()
    {
        pause.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                PauseOff();
            }
            else
            {
                PauseOn();
            }
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
            PauseOff();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
            PauseOff();
        }
    }

    void PauseOn()
    {
        isPaused = true;
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        isPaused = false;
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}