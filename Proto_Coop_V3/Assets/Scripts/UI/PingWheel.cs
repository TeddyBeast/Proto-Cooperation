using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingWheel : MonoBehaviour
{
    UI_Ping Ping;
    public GameObject Wheel;
    public GameObject self;

    private void Awake()
    {
        Ping = Wheel.GetComponent<UI_Ping>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Wheel.SetActive(true);
            Ping.ShowWheel(self);
        }
        if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            Ping.HideWheel();
            Wheel.SetActive(false);
        }
    }
}
