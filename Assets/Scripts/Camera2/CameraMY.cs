using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMY : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0f;
    public float roX;
    private Vector3 velocity = Vector3.zero;
    
    void Update(){
        Vector3 targetPosition = player.position;
        transform.position = targetPosition;
        float MouseY = Input.GetAxis("Mouse Y") * -100f * Time.deltaTime;
        roX += MouseY;
        roX = roX % 361;
    }

    void LateUpdate()
    {
        Vector3 targetRotation = new Vector3(roX, player.eulerAngles.y, player.eulerAngles.z);
        transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref velocity, smoothTime);
    }
}
