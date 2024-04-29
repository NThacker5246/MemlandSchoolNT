using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBreak : MonoBehaviour
{
	public Rigidbody rb;
	void OnTriggerEnter(Collider other){
		if(other.tag == "bottle"){
			rb.isKinematic = false;
		}
	}
}
