using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMYSc : MonoBehaviour
{
    public Transform player;
    void Update(){
        Vector3 targetPosition = player.position;
        Vector3 targetRotation = player.eulerAngles;
        transform.position = targetPosition;
        transform.eulerAngles = targetRotation;
    }
}
