using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Grapple : MonoBehaviour
{
    public GameObject hookStart;

    public GameObject hookEnd;
    //public Camera cameraMire;
    public bool targeted = false;
    private GameObject HookEndGO;
    private Rigidbody rb;
    public LineRenderer LR;
    public SpringJoint Rope;

    [SerializeField] CameraController CamValues;
    [SerializeField] Transform CamTransform;

    [SerializeField] private PlayerInputMovement PlayerSettings;

    [SerializeField] private Image Crosshair;
    //public GameObject CameraVise;

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
            CamValues.aimHold = true;
            //CameraVise.SetActive(true);
            //transform.GetChild(0).gameObject.SetActive(false);

            Vector3 forward = CamTransform.transform.TransformDirection(Vector3.forward) * 1000;

            Debug.DrawRay(CamTransform.transform.position, forward, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(CamTransform.transform.position, forward, out hit) && (hit.transform.tag == "Grap"))
            {
                if (!targeted)
                {
                    Debug.Log("target");
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

        Ray ray = new Ray(CamTransform.transform.position, CamTransform.transform.forward);

        if (CamValues.aimHold == true)
        {
            Crosshair.enabled = enabled;

            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                Debug.DrawRay(CamTransform.transform.position, CamTransform.transform.forward * 1000f, Color.red);

               
            }
        }

        if (CamValues.aimRelease == true)
        {
            PlayerSettings.enabled = enabled;
            Crosshair.enabled = false;
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
