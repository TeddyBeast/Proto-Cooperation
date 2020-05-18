using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluieObject : MonoBehaviour
{
    public GameObject ObjectPrefab;

    public Vector3 size;

    public float speedSpawn = 0.5f;
    float timer = 0f;
    public float lifeTimeObjects = 5f;

    GameObject GO;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= speedSpawn)
        {
            SpawnObjects();
            timer = 0f;
        }
    }

    public void SpawnObjects()
    {
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GO = Instantiate(ObjectPrefab, pos, Quaternion.identity);

        Destroy(GO, lifeTimeObjects);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
