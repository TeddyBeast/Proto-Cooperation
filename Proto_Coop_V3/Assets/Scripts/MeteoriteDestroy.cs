using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDestroy : MonoBehaviour
{
    public GameObject boum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Movable Plateform"))
        {
            Instantiate(boum, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
