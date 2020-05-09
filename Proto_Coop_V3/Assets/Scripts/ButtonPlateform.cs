using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlateform : MonoBehaviour
{
    public GameObject Porte;

    public Material ButtonOff;
    public Material ButtonOn;

    public float openSpeed = 0.2f;
    public float OuvertureMaxPorte = 5f;
    public float OuvertureMinPorte = 0f;

    public bool ouverture = false;
    public bool fermeture = false;

    private void Start()
    {
        OuvertureMinPorte = Porte.transform.position.y;
    }

    private void Update()
    {
        //Porte s'ouvre
        if (ouverture == true && Porte.transform.position.y <= OuvertureMaxPorte)
        {
            Vector3 posPorte = Porte.transform.position;
            posPorte.y += openSpeed;
            Porte.transform.position = posPorte;
        }
        if (Porte.transform.position.y >= OuvertureMaxPorte)
        {
            ouverture = false;
        }

        if (fermeture == true && Porte.transform.position.y >= OuvertureMinPorte)
        {
            Vector3 posPorte = Porte.transform.position;
            posPorte.y -= openSpeed;
            Porte.transform.position = posPorte;
        }
        if (Porte.transform.position.y <= OuvertureMinPorte)
        {
            fermeture = false;
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

            // Start Open Door
            if (OuvertureMaxPorte <= 5f)
            {
                fermeture = false;
                ouverture = true;
            }
            

            GetComponent<Renderer>().material = ButtonOn;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))
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
