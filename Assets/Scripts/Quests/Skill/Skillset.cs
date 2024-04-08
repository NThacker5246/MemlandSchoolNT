using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillset : MonoBehaviour
{
	private Animator anim;
	private PlayerC2 Player; 
	public int orbs;
	public Text orbtxt;

	private void Start(){
		anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>();
	}

	public void SkillShow(){
		anim.SetBool("Skill", true);
	}

	/*
	public void SkillUP(string Name, int cost, int sync){
		if(Name == "speed"){
			Player.speed += sync;
			counts[0].text = "" + Player.speed;
		} else if(Name == "jump") {
			Player.jumpForce += (float) sync;
			counts[1].text = "" + Player.jumpForce;
		}
	}
	*/
	
	public void SkillHide(){
		anim.SetBool("Skill", false);
	}

	public void SkillUp(){
		orbtxt.text = "Орбы: " + orbs;
	}
}
