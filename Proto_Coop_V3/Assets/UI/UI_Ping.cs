using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ping : MonoBehaviour
{
    public GameObject HiGO;
    public GameObject ThanksGO;
    public GameObject FckGO;
    public GameObject HereGO;
    public GameObject JumpGO;

    public GameObject PingPlayer;

    public void ShowWheel(GameObject Player)
    {
        PingPlayer = Player;
        Cursor.visible = true;

    }

    public void HideWheel()
    {
        Cursor.visible = false;
    }

    public void Hi()
    {
        GameObject Ui_Hi = Instantiate(HiGO, PingPlayer.transform.position + Vector3.up * 5, Quaternion.identity);
        //Ui_Hi.transform.LookAt(PingPlayer.transform, Vector3.up);
        Destroy(Ui_Hi, 5);
    }
    public void Here()
    {
        GameObject Ui_Here = Instantiate(HereGO, PingPlayer.transform.position + Vector3.up * 5, Quaternion.identity);
        //Ui_Here.transform.LookAt(PingPlayer.transform, Vector3.up);
        Destroy(Ui_Here, 5);
    }
    public void Thanks()
    {
        GameObject Ui_Thx = Instantiate(ThanksGO, PingPlayer.transform.position + Vector3.up * 5, Quaternion.identity);
        //Ui_Thx.transform.LookAt(PingPlayer.transform, Vector3.up);
        Destroy(Ui_Thx, 5);
    }
    public void Fck()
    {
        GameObject Ui_Fck = Instantiate(FckGO, PingPlayer.transform.position + Vector3.up * 5, Quaternion.identity);
        //Ui_Fck.transform.LookAt(PingPlayer.transform, Vector3.up);
        Destroy(Ui_Fck, 5);
    }
    public void Jump()
    {
        GameObject Ui_Jump = Instantiate(JumpGO, PingPlayer.transform.position + Vector3.up * 5, Quaternion.identity);
        //Ui_Jump.transform.LookAt(PingPlayer.transform, Vector3.up);
        Destroy(Ui_Jump, 5);
    }
}
