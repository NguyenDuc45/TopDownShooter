using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    public bool enableFollowing = true;
    public float smoothSpeed = 10f;
    public Vector3 offset = new Vector3(0, 0, -1);

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (enableFollowing)
        {
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }

        else transform.position = new Vector3(0, 0, -10);
    }
}
