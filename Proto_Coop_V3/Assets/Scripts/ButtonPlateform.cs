using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlateform : MonoBehaviour
{
    public GameObject Plateform;

    public Material ButtonOff;
    public Material ButtonOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 pos = transform.position;
            pos.y = -0.15f;
            transform.position = pos;

            Plateform.SetActive(true);

            GetComponent<Renderer>().material = ButtonOn;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 pos = transform.position;
            pos.y = 0.15f;
            transform.position = pos;

            Plateform.SetActive(false);

            GetComponent<Renderer>().material = ButtonOff;
        }
    }
}
