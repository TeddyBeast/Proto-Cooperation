using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour
{
    public Vector3 SavePos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Agent Hostile")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Mort", transform.position);
            transform.position = SavePos;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}