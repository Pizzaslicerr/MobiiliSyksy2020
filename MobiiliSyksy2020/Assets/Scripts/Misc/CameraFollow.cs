//Tehnyt: Emilia Leinonen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraDistanceFromPlayer;

    //what we are following
    public Transform target;

    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float smoothTime = .15f;

    //enable and set the maximum y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //enable and set the minimum y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //enable and set the maximum x value
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //enable and set the minimum x value
    public bool XMinEnabled = false;
    public float XMinValue = 0;

    private void Start()
    {
        target = GameObject.FindWithTag("CameraTarget").transform;
    }
    void FixedUpdate()
    {
        //target position
        Vector3 targetPos = target.position;

        //vertical
        if (YMinEnabled && YMaxEnabled)

            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);

        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);

        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);

        //horizontal
        if (XMinEnabled && XMaxEnabled)

            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);

        else if (XMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);

        else if (XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);

        //align the camera and the targets z position
        targetPos.z = transform.position.z;

        //gameObject.transform.position = new Vector3(target.position.x + cameraDistanceFromPlayer, 0, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }
}