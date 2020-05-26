using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierre_Save : MonoBehaviour
{
    public Transform PointSpawnPlayer1;
    public Transform PointSpawnPlayer2;

    ParticleSystem Orbe;

    private Vector3 posSpawn;

    public bool SaveActivated = false;

    bool Player1Inside = false;
    bool Player2Inside = false;

    PositionSave Player1;
    PositionSave Player2;


    private void Start()
    {
        Orbe = GetComponent<ParticleSystem>();
        Orbe.Stop();
    }

    private void Update()
    {
        if (SaveActivated == false)
        {
            if (Player1Inside == true && Player2Inside == true && Player1.SavePressed == true && Player2.SavePressed == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Checkpoint", transform.position);
                Orbe.Play();
                SaveActivated = true;

                Player1.SavePos = PointSpawnPlayer1.position;
                Player2.SavePos = PointSpawnPlayer2.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SaveActivated == false)
        {
            if (other.gameObject.CompareTag("Player 1"))
            {
                Player1 = other.GetComponent<PositionSave>();
                Player1Inside = true;
            }
            if (other.gameObject.CompareTag("Player 2"))
            {
                Player2 = other.GetComponent<PositionSave>();
                Player2Inside = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Player1Inside = false;
        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            Player2Inside = false;
        }
    }
}
