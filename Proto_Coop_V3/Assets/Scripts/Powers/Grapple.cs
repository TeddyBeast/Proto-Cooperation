using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject hookStart;

    public GameObject hookEnd;
    public Camera cameraMire;
    public bool targeted = false;
    private GameObject HookEndGO;
    private Rigidbody rb;
    public LineRenderer LR;
    public SpringJoint Rope;
    public GameObject CameraVise;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") & targeted)
        {
            //Debug.Log("Shooting");
            ShootHook();
        }
        else if (Input.GetKey(KeyCode.M))
        {
            CameraVise.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);

            Vector3 forward = hookStart.transform.TransformDirection(Vector3.forward) * 1000;

            Debug.DrawRay(hookStart.transform.position, forward, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(hookStart.transform.position, forward, out hit) && (hit.transform.tag == "Grap"))
            {
                if (!targeted)
                {
                    HookEndGO = Instantiate(hookEnd, hit.point, Quaternion.identity);
                    targeted = true;
                }
                else
                {
                    HookEndGO.transform.position = hit.point;
                }

            }
            else
            {
                //targeted = false;
                //Destroy(HookEndGO);
            }
        }

        if (Input.GetButton("Fire2") & targeted)
        {
            targeted = false;
            Destroy(HookEndGO);
            //LR.enabled = false;
            LR.positionCount = 0;
            Rope = null;
            Destroy(GetComponent<SpringJoint>());
        }
    }

    public void ShootHook()
    {
        Destroy(Rope);
        transform.position = Vector3.MoveTowards(transform.position, HookEndGO.transform.position, 1);
        //LR.enabled = true;
        LR.positionCount = 2;
        LR.SetPosition(0, transform.position);
        LR.SetPosition(1, HookEndGO.transform.position);

        Rope = gameObject.AddComponent<SpringJoint>();
        //newRope.enableCollision = false;
        Rope.autoConfigureConnectedAnchor = false;
        Rope.connectedAnchor = HookEndGO.transform.position;
        Rope.spring = 6.5f;
        Rope.damper = 2f;
        //GameObject.DestroyImmediate(Rope);
        //Rope = newRope;
    }
}
