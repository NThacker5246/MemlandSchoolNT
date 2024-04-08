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
		*/
		if(StartButton.isStoppedCurrentDialogue){
			StartButton.isStoppedCurrentDialogue = false;
			MovementAI.Go = true;
		}

		if(MovementAI.i == 3 && !isUp){
			StartButton.Count++;
			MovementAI.Go = false;
			StartButton.isStoppedCurrentDialogue = true;
			isUp = true;
			StartCoroutine("reset");
		}
	}

	IEnumerator reset(){
		yield return new WaitForSeconds(1f);
		isUp = false;
	}
}
