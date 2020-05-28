using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugs : MonoBehaviour
{
    private FMOD.Studio.EventInstance event_fmod;

    private void Start()
    {
        event_fmod = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiance");
        event_fmod.start();
    }


    void Update()
    {
        // Restart Scene
        if (Input.GetKeyDown(KeyCode.P))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
