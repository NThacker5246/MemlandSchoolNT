using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

	//Define

	[SerializeField] private Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}

	//OptiBody

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			rb.isKinematic = false;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			rb.isKinematic = true;
		}
	}
}
