using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    [SerializeField] private PortalPower portals;
    [SerializeField] private float distanceSpawnPortal = 2f;

    private void Start()
    {
        portals = FindObjectOfType(typeof(PortalPower)) as PortalPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (portals.listPortal.Count > 1)
        {
            if (collision.gameObject.tag == "PortalA")
            {
                foreach (GameObject portal in portals.listPortal)
                {
                    if (portal.tag == "PortalB")
                    {
                        print("Find portalB");
                        transform.position = portal.transform.position - portal.transform.forward * distanceSpawnPortal;
                    }
                }
            }

            if (collision.gameObject.tag == "PortalB")
            {
                foreach (GameObject portal in portals.listPortal)
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
