using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisee : MonoBehaviour
{
    public int vitesseDeplacement = 10;
    public float vitesseRotation = 10;
    public GameObject OriginalCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(-(Input.GetAxis("Mouse Y Player 2") * 3.6f * vitesseRotation * Time.deltaTime), 0, 0, Space.Self);
        transform.Rotate(0, (Input.GetAxis("Mouse X Player 2") * 3.6f * vitesseRotation * Time.deltaTime), 0, Space.World);
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            OriginalCamera.SetActive(true);
            gameObject.SetActive(false);
        }
    }

   
}
