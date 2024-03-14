using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMY : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    void Update(){
        Vector3 targetPosition = player.position;
        transform.position = targetPosition;

    }

    void LateUpdate()
    {
        Vector3 targetRotation = player.eulerAngles;
        transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref velocity, smoothTime);
    }
}
