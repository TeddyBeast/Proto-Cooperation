using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour
{
    public bool playerDead = false;
    public GameObject OtherPlayer;

    public Vector3 SavePos;

    void Respawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Mort");
        transform.position = SavePos;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Agent Hostile")
        {
            OtherPlayer.GetComponent<PositionSave>().Respawn();
            Respawn();
        }
    }

}