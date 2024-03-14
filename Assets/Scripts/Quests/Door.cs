using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator anim;
	private void Start(){
		anim = gameObject.GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player" || other.tag == "NPC"){
			anim.SetBool("Door", true);
		}
	}

	private void OnTriggerExit(Collider other){
		if(other.tag == "Player" || other.tag == "NPC"){
			anim.SetBool("Door", false);
		}
	}
}
