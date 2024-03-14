using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour
{
	private void OnTriggerEnter(Collider other){
		if(other.tag == "ground"){
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>().isGrounded = true;
			Debug.Log("Ring jump");
		}
	}
	private void OnTriggerExit(Collider other){
		if(other.tag == "ground"){
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>().isGrounded = false;
		}
	}
}