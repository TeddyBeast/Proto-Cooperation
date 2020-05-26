using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierre_Save : MonoBehaviour
{
    public Transform PointSpawnPlayer1;
    public Transform PointSpawnPlayer2;

    public AffichageUI UISavePlayer1;
    public AffichageUI UISavePlayer2;


    //ParticleSystem Orbe;

    private Vector3 posSpawn;

    public bool SaveActivated = false;

    bool Player1Inside = false;
    bool Player2Inside = false;

    PositionSave Player1;
    PositionSave Player2;


    private void Start()
    {
        UISavePlayer1.DisableImage();
        UISavePlayer2.DisableImage();
        //Orbe = GetComponent<ParticleSystem>();
        //Orbe.Stop();
        
    }

    private void Update()
    {
        if (SaveActivated == false)
        {
            if (Player1Inside == true && Player2Inside == true && Player1.SavePressed == true && Player2.SavePressed == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Checkpoint", transform.position);
                transform.GetChild(0).gameObject.SetActive(true);
                //Orbe.Play();
                
                SaveActivated = true;

                Player1.SavePos = PointSpawnPlayer1.position;
                Player2.SavePos = PointSpawnPlayer2.position;
            }
        }
        else if (SaveActivated == true)
        {
            UISavePlayer1.DisableImage();
            UISavePlayer2.DisableImage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SaveActivated == false)
        {
            if (other.gameObject.CompareTag("Player 1"))
            {
                UISavePlayer1.EnableImage();

                Player1 = other.GetComponent<PositionSave>();
                Player1Inside = true;
            }
            if (other.gameObject.CompareTag("Player 2"))
            {
                UISavePlayer2.EnableImage();

                Player2 = other.GetComponent<PositionSave>();
                Player2Inside = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            UISavePlayer1.DisableImage();

            Player1Inside = false;
        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            UISavePlayer2.DisableImage();

            Player2Inside = false;
        }
    }
}
