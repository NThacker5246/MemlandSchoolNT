/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeAIController : MonoBehaviour
{
	public Patrol MovementAI;
	public DialogueTrigger StartButton;
	public bool isUp;

	public void Update(){
		/*
		if(StartButton.isStoppedCurrentDialogue && MovementAI.i == 4){
			StartButton.isStoppedCurrentDialogue = false;
			StartButton.Count++;
			MovementAI.Go = false;
		}
		//
		if(StartButton.isStoppedCurrentDialogue){
			StartButton.isStoppedCurrentDialogue = false;
			MovementAI.Go = true;
		}

		if(MovementAI.i == 3 && !isUp){
			StartButton.Count++;
			MovementAI.Go = false;
			//StartButton.isStoppedCurrentDialogue = true;
			isUp = true;
			//StartCoroutine("reset");
		}

		if(MovementAI.i == 16 && !isUp){
			StartButton.Count++;
			MovementAI.Go = false;
			//StartButton.isStoppedCurrentDialogue = true;
			isUp = true;
			//StartCoroutine("reset");
		}
	}

	IEnumerator reset(){
		yield return new WaitForSeconds(1f);
		isUp = false;
	}
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeAIController : MonoBehaviour
{
	public Patrol MovementAI;
	//public DialogueTrigger StartButton;
	public bool isUp;
	public DiaMan dm;
	private bool ToMovePortal;
	public Button1 btn;

	public void Update(){
		if(dm.isStCD){
			//StartButton.isStoppedCurrentDialogue = false;
			dm.isStCD = false;
			MovementAI.Go = true;
			StartCoroutine("reset");
		}

		if(MovementAI.i == 3 && !isUp){
			dm.i++;
			MovementAI.Go = false;
			isUp = true;
		}

		if(MovementAI.i == 16 && !isUp){
			dm.i++;
			MovementAI.Go = false;
			isUp = true;
		}

		if(MovementAI.i == 17 && !isUp){
			dm.i++;
			MovementAI.Go = false;
			isUp = true;
			ToMovePortal = true;
		}
		if(ToMovePortal){
			if(btn.isDid){
				StartCoroutine("Go");
				ToMovePortal = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "pt"){
			gameObject.SetActive(false);
		}
	}

	IEnumerator reset(){
		yield return new WaitForSeconds(1f);
		isUp = false;
	}

	IEnumerator Go(){
		yield return new WaitForSeconds(1f);
		MovementAI.Go = true;
	}
}
