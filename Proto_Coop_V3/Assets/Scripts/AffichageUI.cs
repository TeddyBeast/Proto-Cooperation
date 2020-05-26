using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageUI : MonoBehaviour
{
    public Image nameLable;
    public Camera CamPlayer;


    void Update()
    {
        Vector3 namePose = CamPlayer.WorldToScreenPoint(this.transform.position);
        nameLable.transform.position = namePose;
    }

    public void EnableImage()
    {
        nameLable.enabled = true;
    }

    public void DisableImage()
    {
        nameLable.enabled = false;
    }
}
