using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if(gameOver)
        {
            Quit();
        }
    }

    void Quit()
    {
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
    }
}
