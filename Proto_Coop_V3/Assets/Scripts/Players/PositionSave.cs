using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour
{
    public Vector3 SavePos;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Agent Hostile")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Mort", transform.position);
            transform.position = SavePos;
        }
    }

}
