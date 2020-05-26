using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    public ListPortalsPlaced ListPortals;

    [SerializeField] private float distanceSpawnPortal = 2f;

    public float timer = 2f;

    private void Start()
    {
        ListPortals = FindObjectOfType(typeof(ListPortalsPlaced)) as ListPortalsPlaced;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ListPortals.PortalsPlaced.Count > 1)
        {
            if (other.gameObject.tag == "PortalA" && timer <= 0)
            {
                foreach (GameObject portal in ListPortals.PortalsPlaced)
                {
                    if (portal.tag == "PortalB")
                    {
                        print("Find portalB");
                        transform.position = portal.transform.position/* - portal.transform.forward * distanceSpawnPortal*/;
                        transform.position -= transform.forward * 2;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Utiliser Portail", transform.position);
                        timer = 2f;
                    }
                }
            }

            if (other.gameObject.tag == "PortalB" && timer <= 0)
            {
                foreach (GameObject portal in ListPortals.PortalsPlaced)
                {
                    if (portal.tag == "PortalA")
                    {
                        transform.position = portal.transform.position/* - portal.transform.forward * distanceSpawnPortal*/;
                        transform.position -= transform.forward * 2;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Utiliser Portail", transform.position);
                        timer = 2f;
                    }
                }
            }
        }
    }
}
