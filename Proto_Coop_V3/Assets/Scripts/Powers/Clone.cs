using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cloneGO;
    public Vector3 playerVelocity;
    private GameObject clone;
    public bool cloned = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & cloned)
        {
            Destroy(clone);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            clone = Instantiate(cloneGO, transform.position, transform.rotation);
            //playerVelocity = rb.velocity;
            //clone.GetComponent<Rigidbody>().AddForce(playerVelocity * 2 + Vector3.up * 5, ForceMode.VelocityChange);
            //clone.GetComponent<BoxCollider>().enabled = false;
            //StartCoroutine(RebuildCollision());
            cloned = true;
        }
        if (Input.GetKeyDown(KeyCode.R) & cloned)
        {
            transform.position = clone.transform.position;
            Destroy(clone);
            cloned = false;
        }
    }

    //IEnumerator RebuildCollision()
    //{
    //    if (cloned)
    //    {
    //        yield return new WaitForSeconds(0.01f);
    //        clone.GetComponent<BoxCollider>().enabled = true;
    //    }
    //}
}
