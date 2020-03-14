using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FusionBetweenPlayer : MonoBehaviour
{
    public GameObject BigPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player 2"))
        {
            Instantiate(BigPlayer, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject.GetComponentInChildren(typeof(Camera)) as Camera);
            Destroy(collision.gameObject);
            Destroy(gameObject.GetComponentInChildren(typeof(Camera)) as Camera);
            Destroy(gameObject);
            
        }
    }
}
