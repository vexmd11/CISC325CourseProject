using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnableButton : MonoBehaviour
{
    public Button startGameButton;

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Maze");

            if (obj != null)
            {
                startGameButton.enabled = true;
            }
        }else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Platform");

            if (obj != null)
            {
                startGameButton.enabled = true;
            }
        }
        
    }
}
