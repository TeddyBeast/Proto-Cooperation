using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBigPlayer : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private void Update()
    {
        if (Input.GetButtonDown("Split"))
        {
            Destroy(gameObject.GetComponentInChildren(typeof(Camera)) as Camera);
            Destroy(gameObject);
            Instantiate(Player1, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(Player2, new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
