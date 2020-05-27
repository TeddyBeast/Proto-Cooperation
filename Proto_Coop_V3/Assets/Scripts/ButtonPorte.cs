using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPorte : MonoBehaviour
{
    public GameObject Porte;

    public Material ButtonOff;
    public Material ButtonOn;

    public MeshRenderer ButtonRune;

    public float openSpeed = 0.2f;
    public float ouvertureMaxPorte = 10f;
    public float ouvertureMinPorte = 0f;
    float ouvertureMax = 0f;

    public float pressionMaxButton = -0.10f;

    bool ouverture = false;
    bool fermeture = false;

    public bool MaintienBouton = false;
    public bool ActiveBouton = false;
    public bool ActiveTimerButton = false;
    public float DurationOpenDoor = 3f;
    float timer = 0f;

    private void Start()
    {
        ouvertureMinPorte = Porte.transform.localPosition.y;
        ouvertureMax = Porte.transform.localPosition.y + ouvertureMaxPorte;
    }

    private void Update()
    {
        #region Maintien Boutton
        if (MaintienBouton == true)
        {
            //Porte s'ouvre
            if (ouverture == true && Porte.transform.localPosition.y >= ouvertureMax)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y -= openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y <= ouvertureMax)
            {
                ouverture = false;
            }

            if (fermeture == true && Porte.transform.localPosition.y <= ouvertureMinPorte)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y += openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y >= ouvertureMinPorte)
            {
                fermeture = false;
            }
        }
        #endregion Maintien Button

        #region Active Boutton
        if (ActiveBouton == true)
        {
            if (ouverture == true)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y -= openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y <= ouvertureMax)
            {
                ouverture = false;
            }
        }
        #endregion Active Boutton

        #region TimerButton
        if (ActiveTimerButton == true)
        {
            timer += Time.deltaTime;

            if (ouverture == true && fermeture==false)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y -= openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y <= ouvertureMax)
            {
                ouverture = false;
            }

            if (timer >= DurationOpenDoor)
            {
                fermeture = true;
            }

            if (fermeture == true && Porte.transform.localPosition.y <= ouvertureMinPorte)
            {
                Vector3 posPorte = Porte.transform.localPosition;
                posPorte.y += openSpeed;
                Porte.transform.localPosition = posPorte;
            }
            if (Porte.transform.localPosition.y >= ouvertureMinPorte)
            {
                fermeture = false;
                timer = 0f;

                //Button position
                Vector3 pos = transform.position;
                pos.y = 0.15f;
                transform.position = pos;

                ButtonRune.material = ButtonOff;
            }
            #endregion TimerButton
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2") || other.gameObject.CompareTag("Coco"))
        {
            //Button position
            Vector3 pos = transform.position;
            pos.y += pressionMaxButton;
            transform.position = pos;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton Porte", transform.position);

            ButtonRune.material = ButtonOn;

            if (MaintienBouton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y >= ouvertureMax)
                {
                    fermeture = false;
                    ouverture = true;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Porte", transform.position);
                }
            }

            if (ActiveBouton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y >= ouvertureMax)
                {
                    ouverture = true;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Porte", transform.position);
                }
            }

            if (ActiveTimerButton == true)
            {
                // Start Open Door
                if (Porte.transform.localPosition.y >= ouvertureMax)
                {
                    ouverture = true;
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Porte", transform.position);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2") || other.gameObject.CompareTag("Coco"))
        {
            if (MaintienBouton == true)
            {
                //Button position
                Vector3 pos = transform.position;
                pos.y -= pressionMaxButton;
                transform.position = pos;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Bouton Porte", transform.position);

                //Start Close Door
                ouverture = false;
                fermeture = true;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Porte", transform.position);


                ButtonRune.material = ButtonOff;
            }
        }
    }
}
