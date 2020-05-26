using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertionPower : MonoBehaviour
{
    [SerializeField] bool Player1Inside = false;
    [SerializeField] bool Player2Inside = false;

    [SerializeField] Telekinesie TelePlayer1;
    [SerializeField] Telekinesie TelePlayer2;

    [SerializeField] PortalPower PortalPlayer1;
    [SerializeField] PortalPower PortalPlayer2;

    private void Update()
    {
        if (TelePlayer1 != null && PortalPlayer1 != null && TelePlayer2 != null && PortalPlayer2 != null)
        {
            if (Player1Inside == true && Player2Inside == true)
            {
                TelePlayer1.enabled = false;
                PortalPlayer1.enabled = true;

                TelePlayer2.enabled = true;
                PortalPlayer2.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Player1Inside = true;
            TelePlayer1 = other.GetComponent<Telekinesie>();
            PortalPlayer1 = other.GetComponent<PortalPower>();
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            Player2Inside = true;
            TelePlayer2 = other.GetComponent<Telekinesie>();
            PortalPlayer2 = other.GetComponent<PortalPower>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Player1Inside = false;

            TelePlayer1.enabled = true;
            PortalPlayer1.enabled = false;
            TelePlayer2.enabled = false;
            PortalPlayer2.enabled = true;
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            Player2Inside = false;

            TelePlayer1.enabled = true;
            PortalPlayer1.enabled = false;
            TelePlayer2.enabled = false;
            PortalPlayer2.enabled = true;
        }
    }
}
