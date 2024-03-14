using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillset : MonoBehaviour
{
	private Animator anim;
	private PlayerC2 Player;

	private void Start(){
		anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>();
	}

	public void SkillShow(){
		anim.SetBool("Skill", true);
	}
	
	public void SkillHide(){
		anim.SetBool("Skill", false);
	}

	public void SkillUpgrade(string Name, int cost, int sync){
		if(Name == "speed"){
			Player.speed += sync;
		} else if(Name == "jump") {
			Player.jumpForce += (float) sync;
		}
	}
}
