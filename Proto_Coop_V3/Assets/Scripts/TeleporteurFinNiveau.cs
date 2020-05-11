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
            other.transform.position = PointPlayer1.transform.position;
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            other.transform.position = PointPlayer2.transform.position;
        }
    }
}
