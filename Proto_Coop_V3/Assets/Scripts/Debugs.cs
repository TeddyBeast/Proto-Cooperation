using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugs : MonoBehaviour
{
    void Update()
    {
        // Restart Scene
        if (Input.GetKeyDown(KeyCode.P))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
