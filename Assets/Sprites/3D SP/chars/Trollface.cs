using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trollface : MonoBehaviour
{
	private Transform player;
	private Rigidbody rb;
	private Animator anim;
	
	private void Start(){
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	public void WalkToPlayer(){
		Vector3 move = new Vector3(player.position.x, player.position.y, player.position.z);
		anim.SetBool("Walk", true);
		rb.AddForce(move);
		if(GetComponent<Transform>().position.x == player.position.x && GetComponent<Transform>().position.z == player.position.z){
			anim.SetBool("Walk", false);
			return;
		}
	}
}