using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    public bool lockCursor;
    public float sensivity = 2f;
    public Transform target;
    public PlayerMovement PlayerStat;
    public float distFromTarget = 11f;
    public Vector2 pitchMinMax = new Vector2(-40f, 85f);

    public float rotationSmoothTime = 10f;
    Vector3 currentRotation;

    float h;
    float v;

    [Header("Aiming Vars")]
    public Vector3 playerOffset;
    public float distanceFromOffset = 2f;
    public Transform rotator;

    [Header("Transparency")]
    public bool changeTransparency = true;
    public MeshRenderer targetRenderer;

    [Header("Speeds")]
    public float moveSpeed = 5f;
    public float returnSpeed = 9f;
    public float wallPush = 0.16f;

    [Header("Distances")]
    public float closestDistanceToPlayer = 2f;
    public float evenCloserDistanceToPlayer = 1f;

    [Header("Mask")]
    public LayerMask collisionMask;

    private bool vLock = false;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 r = target.TransformPoint(playerOffset);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(r, 0.1f);
    }

    private void ThirdPersonAiming()
    {
        CollisionCheck((target.TransformPoint(playerOffset) - transform.forward * distanceFromOffset));


        h += hinput.gamepad[PlayerStat.Player].rightStick.horizontal * sensivity;
        v -= hinput.gamepad[PlayerStat.Player].rightStick.vertical * sensivity;
        v = Mathf.Clamp(v, pitchMinMax.x, pitchMinMax.y);
        currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);

        transform.eulerAngles = currentRotation;
        Vector3 e = transform.eulerAngles;
        e.x = 0;
        Vector3 g = transform.eulerAngles;
        g.y = 0;

        rotator.eulerAngles = new Vector3(g.x, rotator.eulerAngles.y, rotator.eulerAngles.z);

        target.eulerAngles = e;
    }

    private void LateUpdate()
    {

        if (hinput.gamepad[PlayerStat.Player].leftTrigger.justPressed)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (hinput.gamepad[PlayerStat.Player].leftTrigger.pressed)
        {
            ThirdPersonAiming();
            Transparency(0.2f);
        }
        else
        {

            rotator.eulerAngles = new Vector3(0, rotator.eulerAngles.y, rotator.eulerAngles.z);

            CollisionCheck(target.position - transform.forward * distFromTarget);
            WallCheck();


            if (!vLock)
            {
                h += hinput.gamepad[PlayerStat.Player].rightStick.horizontal * sensivity;
                v -= hinput.gamepad[PlayerStat.Player].rightStick.vertical * sensivity;
                v = Mathf.Clamp(v, pitchMinMax.x, pitchMinMax.y);
                currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);
            }
            else
            {

                h += hinput.gamepad[PlayerStat.Player].rightStick.horizontal * sensivity;
                v = pitchMinMax.y;

                currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);

            }


            transform.eulerAngles = currentRotation;

            Vector3 e = transform.eulerAngles;
            e.x = 0;

            target.eulerAngles = e;

        }


    }

    private void WallCheck()
    {

        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.2f, out hit, 0.7f, collisionMask))
        {
            vLock = true;
        }
        else
        {
            vLock = false;
        }

    }

    private void CollisionCheck(Vector3 retPoint)
    {

        RaycastHit hit;

        if (Physics.Linecast(target.position, retPoint, out hit, collisionMask))
        {

            Vector3 norm = hit.normal * wallPush;
            Vector3 p = hit.point + norm;

            TransparencyCheck();

            if (Vector3.Distance(Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
            {


            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
            }

            return;

        }


        FullTransparency();

        transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
        vLock = false;


    }

    private void TransparencyCheck()
    {

        if (changeTransparency)
        {

            if (Vector3.Distance(transform.position, target.position) <= closestDistanceToPlayer)
            {

                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;


            }
            else
            {

                if (targetRenderer.sharedMaterial.color.a <= 0.99f)
                {

                    Color temp = targetRenderer.sharedMaterial.color;
                    temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                    targetRenderer.sharedMaterial.color = temp;

                }

            }

        }

    }

    private void FullTransparency()
    {
        if (changeTransparency)
        {
            if (targetRenderer.sharedMaterial.color.a <= 0.99f)
            {

                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;

            }
        }
    }

    private void Transparency(float t)
    {

        Color temp = targetRenderer.sharedMaterial.color;
        temp.a = Mathf.Lerp(temp.a, t, moveSpeed * Time.deltaTime);

        targetRenderer.sharedMaterial.color = temp;


    }
}
