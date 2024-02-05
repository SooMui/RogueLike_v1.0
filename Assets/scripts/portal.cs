using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    // public string sceneName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
    SceneManager.LoadScene(6);
        
        // Debug.Log("Object touched!");
    }
}
