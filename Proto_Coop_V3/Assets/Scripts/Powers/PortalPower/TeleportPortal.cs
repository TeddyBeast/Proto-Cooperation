using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    public ListPortalsPlaced ListPortals;
    public CameraController cam;

    [SerializeField] private float distanceSpawnPortal = 2f;

    private void Start()
    {
        ListPortals = FindObjectOfType(typeof(ListPortalsPlaced)) as ListPortalsPlaced;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ListPortals.PortalsPlaced.Count > 1)
        {
            if (other.gameObject.tag == "PortalA")
            {
                foreach (GameObject portal in ListPortals.PortalsPlaced)
                {
                    if (portal.tag == "PortalB")
                    {
                        print("Find portalB");
                        transform.position = portal.transform.position - portal.transform.forward * distanceSpawnPortal;
                    }
                }
            }

            if (other.gameObject.tag == "PortalB")
            {
                foreach (GameObject portal in ListPortals.PortalsPlaced)
                {
                    if (portal.tag == "PortalA")
                    {
                        transform.position = portal.transform.position - portal.transform.forward * distanceSpawnPortal;
                    }                
                }
            }
        }
    }
}
