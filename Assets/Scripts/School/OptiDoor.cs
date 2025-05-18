using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptiDoor : MonoBehaviour
{
	[SerializeField] private GameObject forward;
	[SerializeField] private GameObject backward;
	[SerializeField] private byte axis; // 0 - z, 1 - x
	[SerializeField] private Animator anim;
	[SerializeField] private Collider player;

	void Awake(){
		OnTriggerExit(player);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag != "Player") return;
		Transform tf = other.transform;
		if(axis == 0){
			if(tf.position.z < transform.position.z){
				anim.SetBool("forward", true);
				anim.SetBool("backward", false);
				//forward.SetActive(true);
			} else if(tf.position.z > transform.position.z) {
				anim.SetBool("backward", true);
				anim.SetBool("forward", false);
				//backward.SetActive(true);
			}
		} else if(axis == 1){
			if(tf.position.x > transform.position.x){
				//forward.SetActive(true);
			} else if(tf.position.x < transform.position.x) {
				//backward.SetActive(true);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag != "Player") return;
		/*
		Transform tf = other.transform;
		anim.SetBool("Anima", false);
		if(axis == 0){
			if(tf.position.z < transform.position.z){
				//forward.SetActive(false);
			} else if(tf.position.z > transform.position.z) {
				//backward.SetActive(false);
			}
		} else if(axis == 1){
			if(tf.position.x > transform.position.x){
				//forward.SetActive(false);
			} else if(tf.position.x < transform.position.x) {
				//backward.SetActive(false);
			}
		}
		*/

		anim.SetBool("forward", false);
		anim.SetBool("backward", false);
	}
}
