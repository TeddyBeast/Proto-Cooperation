using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierre_Save : MonoBehaviour
{
    public Transform PointSpawnPlayer1;
    public Transform PointSpawnPlayer2;

    ParticleSystem Orbe;

    //public GameObject LightSave;

    private Vector3 posSpawn;

    public bool SaveActivated = false;

    private void Start()
    {
        //LightSave.SetActive(false);
        Orbe = GetComponent<ParticleSystem>();
        Orbe.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SaveActivated == false)
        {
            if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Checkpoint", transform.position);
                //LightSave.SetActive(true);
                Orbe.Play();
                SaveActivated = true;
            }

            if (other.gameObject.CompareTag("Player 1"))
            {
                posSpawn = other.gameObject.GetComponent<PositionSave>().SavePos;
                posSpawn = PointSpawnPlayer1.position;
                other.gameObject.GetComponent<PositionSave>().SavePos = posSpawn;
            }

            if (other.gameObject.CompareTag("Player 2"))
            {
                posSpawn = other.gameObject.GetComponent<PositionSave>().SavePos;
                posSpawn = PointSpawnPlayer2.position;
                other.gameObject.GetComponent<PositionSave>().SavePos = posSpawn;
            }
        }
    }
}
