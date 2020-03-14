using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPower : MonoBehaviour
{
    [SerializeField] private GameObject PortalA;
    [SerializeField] private GameObject PortalB;

    [SerializeField] private float distWall = 2f;

    [SerializeField] private GameObject PortalSelected;

    public List<GameObject> listPortal;

    private int NbreSamePortal = 0;

    private void Start()
    {
        PortalSelected = PortalA;
        listPortal = new List<GameObject>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (hinput.gamepad[0].X.pressed)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, distWall))
            {
                Debug.DrawRay(transform.position, transform.forward * distWall, Color.red);
                if (hit.transform.CompareTag("Wall"))
                {
                    if (listPortal.Count == 0)
                    {
                        listPortal.Add(Instantiate(PortalSelected, transform.position + transform.forward, transform.rotation = hit.transform.rotation));
                    }

                    if (listPortal.Count > 0)
                    {
                        foreach (GameObject portal in listPortal)
                        {
                            if (portal.tag == PortalSelected.tag)
                            {
                                portal.transform.position = transform.position + transform.forward;
                                portal.transform.rotation = hit.transform.rotation;
                                NbreSamePortal++;
                            }
                        }
                        
                        if (NbreSamePortal == 0)
                        {
                            listPortal.Add(Instantiate(PortalSelected, transform.position + transform.forward, transform.rotation = hit.transform.rotation));
                            NbreSamePortal = 0;
                        }
                        NbreSamePortal = 0;
                    }
                }
            }
        }

        if (Input.GetButtonDown("Switch Portal"))
        {
            if (PortalSelected == PortalA)
            {
                PortalSelected = PortalB;
            }
            else if (PortalSelected == PortalB)
            {
                PortalSelected = PortalA;
            }
        }

    }
}
