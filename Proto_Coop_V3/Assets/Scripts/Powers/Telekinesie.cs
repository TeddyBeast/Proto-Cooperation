using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class Telekinesie : MonoBehaviour
{
    public float speedPlatform = 7f;
    private bool powerActivate = false;

    [SerializeField] GameObject CamPlayer;

    private GameObject PlateformTouched;

    [SerializeField] private Image Crosshair;

    [SerializeField] private PlayerInputMovement PlayerMovement;

    public ListMovablePlatforms ListPlateforms;

    private void Start()
    {
        ListPlateforms = FindObjectOfType(typeof(ListMovablePlatforms)) as ListMovablePlatforms;
        PlayerMovement = GetComponent<PlayerInputMovement>();
    }

    private void Update()
    {
        Ray ray = new Ray(CamPlayer.transform.position, CamPlayer.transform.forward);
        
        if (hinput.gamepad[0].leftTrigger.pressed)
        {
            Crosshair.enabled = enabled;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Debug.DrawRay(CamPlayer.transform.position, CamPlayer.transform.forward * 1000f, Color.red);

                foreach (GameObject plateform in ListPlateforms.PlateformMovableTelekinesie)
                {
                    if (hit.transform.gameObject == plateform)
                    {
                        PlateformTouched = plateform;
                        PlateformTouched.GetComponent<Outline>().enabled = true;

                        powerActivate = true;
                    }
                }
            }
        }

        if (hinput.gamepad[0].leftTrigger.released)
        {
            PlayerMovement.enabled = enabled;
            Crosshair.enabled = false;

            foreach (GameObject plateform in ListPlateforms.PlateformMovableTelekinesie)
            {
                plateform.GetComponent<Outline>().enabled = false;
            }

            powerActivate = false;
        }


        if (powerActivate == true)
        {
            PlayerMovement.enabled = false;

            Rigidbody rb;
            rb = PlateformTouched.transform.GetComponent<Rigidbody>();

            float h = hinput.gamepad[0].leftStick.horizontal;
            float v = hinput.gamepad[0].leftStick.vertical;

            Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
            desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

            Vector3 targetPos = PlateformTouched.transform.position + desiredMove * speedPlatform * Time.deltaTime;

            rb.MovePosition(targetPos);
        }
    }
}
