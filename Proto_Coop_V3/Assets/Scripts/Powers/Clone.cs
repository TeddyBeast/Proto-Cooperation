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
    public Material Shadow;
    public Material OldMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) & cloned)
        //{
        //    Destroy(clone);
        //}
        if (Input.GetKeyDown(KeyCode.P) & !cloned)
        {
            //clone = Instantiate(cloneGO, transform.position, transform.rotation);

            //OldMaterial = GetComponent<MeshRenderer>().material;
            GetComponent<MeshRenderer>().material = Shadow;

            //playerVelocity = rb.velocity;
            //clone.GetComponent<Rigidbody>().AddForce(playerVelocity * 2 + Vector3.up * 5, ForceMode.VelocityChange);
            //clone.GetComponent<BoxCollider>().enabled = false;
            //StartCoroutine(RebuildCollision());
            cloned = true;
        }
        if (Input.GetKeyDown(KeyCode.L) & cloned)
        {
            //transform.position = clone.transform.position;
            //Destroy(clone);
            GetComponent<MeshRenderer>().material = OldMaterial;
            cloned = false;
        }
    }

    //public void OnCollisionEnter(Collision col)
    //{
    //    if (cloned & col.gameObject.layer == 11)
    //    {
            
    //    }
    //}


    //IEnumerator RebuildCollision()
    //{
    //    if (cloned)
    //    {
    //        yield return new WaitForSeconds(0.01f);
    //        clone.GetComponent<BoxCollider>().enabled = true;
    //    }
    //}
}
