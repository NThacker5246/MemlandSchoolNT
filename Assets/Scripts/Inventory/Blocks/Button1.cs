using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
	public Animator portal;
	private Animator button;
	public bool inColl;
	public bool isDid;

	public void Start(){
		button = GetComponent<Animator>();
		if(isDid){
			button.SetBool("button", true);
			portal.SetBool("open", true);
		}
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
		if(inColl){
			if(Input.GetKeyDown(KeyCode.E)){
				button.SetBool("button", true);
				portal.SetBool("open", true);
				isDid = true;
			}
		}
	}
}
