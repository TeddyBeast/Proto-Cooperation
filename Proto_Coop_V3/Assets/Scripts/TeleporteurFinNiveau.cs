using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteurFinNiveau : MonoBehaviour
{
    public GameObject PointPlayer1;
    public GameObject PointPlayer2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Portal Fin Lvl", transform.position);
            other.transform.position = PointPlayer1.transform.position;

            other.GetComponent<PositionSave>().SavePos = PointPlayer1.transform.position;
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Portal Fin Lvl", transform.position);
            other.transform.position = PointPlayer2.transform.position;

            other.GetComponent<PositionSave>().SavePos = PointPlayer2.transform.position;
        }
    }
}
