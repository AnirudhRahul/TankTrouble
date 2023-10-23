using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenControl : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            // Load the main game scene (replace "MainGame" with the name of your game scene)
            SceneManager.LoadScene("Main");
        }
    }
}

