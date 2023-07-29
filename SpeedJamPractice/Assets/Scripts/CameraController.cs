using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f; //the lower this value, the smoother the lerp, but more delayed

    private Vector3 offset; //just the distance between the player and the camera

    private void Start(){
        offset = transform.position - player.position; //the space between player an camera;
    }


    private void FixedUpdate()
    {
        //simple lerp from the camera's current pos to the new pos of the player
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
