using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlateform : MonoBehaviour
{
    public GameObject Porte;

    public Material ButtonOff;
    public Material ButtonOn;

    public float openSpeed = 0.2f;
    public float OuvertureMaxPorte = 10f;
    public float OuvertureMinPorte = 0f;
    float OuvertureMax = 0f;

    bool ouverture = false;
    bool fermeture = false;

    public bool MaintienBouton = false;
    public bool ActiveBouton = false;
    public bool ActiveTimerButton = false;
    public float DurationOpenDoor = 3f;
    float timer = 0f;

    private void Start()
    {
        OuvertureMinPorte = Porte.transform.localPosition.y;
        OuvertureMax = Porte.transform.localPosition.y + OuvertureMaxPorte;
    }

    private void Update()
    {
        if (MaintienBouton == true)
        {
            //Porte s'ouvre
            if (ouverture == true && Porte.transform.localPosition.y <= OuvertureMax)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y += openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y >= OuvertureMax)
            {
                ouverture = false;
            }

            if (fermeture == true && Porte.transform.localPosition.y >= OuvertureMinPorte)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y -= openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y <= OuvertureMinPorte)
            {
                fermeture = false;
            }
        }

        if (ActiveBouton == true)
        {
            if (ouverture == true)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y += openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y >= OuvertureMax)
            {
                ouverture = false;
            }
        }

        if (ActiveTimerButton == true)
        {
            timer += Time.deltaTime;

            if (ouverture == true)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y += openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y >= OuvertureMax)
            {
                ouverture = false;
            }

            if (timer >= DurationOpenDoor)
            {
                fermeture = true;
            }

            if (fermeture == true && Porte.transform.localPosition.y >= OuvertureMinPorte)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y -= openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y <= OuvertureMinPorte)
            {
                fermeture = false;
                timer = 0f;

                //Button position
                Vector3 pos = transform.position;
                pos.y = 0.15f;
                transform.position = pos;

                GetComponent<Renderer>().material = ButtonOff;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))
        {
            //Button position
            Vector3 pos = transform.position;
            pos.y = -0.15f;
            transform.position = pos;

            GetComponent<Renderer>().material = ButtonOn;

            if (MaintienBouton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y <= OuvertureMax)
                {
                    fermeture = false;
                    ouverture = true;
                }
            }

            if (ActiveBouton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y <= OuvertureMax)
                {
                    ouverture = true;
                }
            }

            if (ActiveTimerButton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y <= OuvertureMax)
                {
                    ouverture = true;
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))
        {
            if (MaintienBouton == true)
            {
                //Button position
                Vector3 pos = transform.position;
                pos.y = 0.15f;
                transform.position = pos;

                //Start Close Door
                ouverture = false;
                fermeture = true;


                GetComponent<Renderer>().material = ButtonOff;
            }
        }
    }
}
