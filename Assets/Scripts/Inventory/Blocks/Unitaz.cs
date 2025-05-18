using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitaz : MonoBehaviour
{
	[SerializeField] private bool inColl;
	[SerializeField] private bool flag;
	[SerializeField] private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	void Update(){
		if(inColl && Input.GetKeyDown(KeyCode.E)){
			flag = !flag;
			anim.SetBool("Open", flag);
		}
	}
}
