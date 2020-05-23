using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ArrowTrap : MonoBehaviour
{
    public List<GameObject> PointSpawnArrows;

    public GameObject Arrow;

    public float durationPause = 4f;
    float timerDurationPause = 0f;

    public float rateArrows = 0.5f;
    float timerRateArrows = 0.5f;

    public int nbreSalveArrows = 5;
    int nbreSalve = 0;

    public float distanceMaxArrows = 3f;

    public float speedArrows = 2f;

    bool StartShoot = false;

    private void Update()
    {
        if (StartShoot == false)
        {
            timerDurationPause += Time.deltaTime;

            if (timerDurationPause >= durationPause)
            {
                StartShoot = true;
            }
        }



        if (StartShoot == true)
        {
            timerRateArrows += Time.deltaTime;

            if (timerRateArrows >= rateArrows && nbreSalve <= nbreSalveArrows)
            {
                foreach (GameObject SpawnPoints in PointSpawnArrows)
                {
                    GameObject GO = Instantiate(Arrow, SpawnPoints.transform.position, SpawnPoints.transform.rotation);
                    GO.GetComponent<Rigidbody>().AddForce(SpawnPoints.transform.forward * speedArrows, ForceMode.Impulse);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Piège Flèches", transform.position);
                    Destroy(GO, distanceMaxArrows);
                }
                nbreSalve++;
                timerRateArrows = 0f;

            }
            else if (nbreSalve > nbreSalveArrows)
            {
                nbreSalve = 0;
                timerRateArrows = 0;
                timerDurationPause = 0f;
                StartShoot = false;
            }
        }
    }
}
