using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
