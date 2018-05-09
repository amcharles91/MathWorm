using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandCast : MonoBehaviour {

    public float TargetDistance;
    public float rayDistance;
    public float rayDur;


    //private void FixedUpdate()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);

    //    RaycastHit hit;

    //    Debug.DrawLine(transform.position, transform.TransformDirection(transform.forward) * rayDistance, Color.red);

    //    if (Physics.Raycast(ray, out hit, rayDistance))
    //    {
    //        TargetDistance = hit.distance;
    //        Debug.DrawLine(hit.point, hit.point + Vector3.up * 5, Color.green, rayDur, true);
    //    }
    //}


    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ShootLaserFromTargetPosition(transform.position, transform.forward, laserMaxLength);
            laserLineRenderer.enabled = true;
        }
        else
        {
            laserLineRenderer.enabled = false;
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
