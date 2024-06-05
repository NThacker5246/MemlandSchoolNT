using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaMan : MonoBehaviour
{
	//for every npc
	public DialogData[] data;
	public int i;
	public int j;
	public Text dialogText;
	public Text nameText;
	public bool inColl;
	public bool isStarted;
	public Animator box;
	public bool isStCD;

	public void NextDialogue(){
		isStarted = true;
		j = 0;
		SentDialog();
	}

	public void SentDialog(){
		StopAllCoroutines();
		box.SetBool("boxOpen", true);
		nameText.text = data[i].name;
		StartCoroutine("DisplayDialog");
	}

	public void NextSent(){
		Debug.Log(j < data[i].senteces.Length);
		if(j < data[i].senteces.Length-1) {
			j += 1;
			SentDialog();
		} else {
			isStarted = false;
			//i += 1;
			box.SetBool("boxOpen", false);
			isStCD = true;
		}
	}

	IEnumerator DisplayDialog(){
		dialogText.text = "";
		DialogData current = data[i];
		string sentece = current.senteces[j];
		char[] sentece1 = sentece.ToCharArray();
		foreach(char letter in sentece1){
			string l = letter.ToString();
			dialogText.text += l;
			yield return null;
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
			if(Input.GetKeyDown(KeyCode.C)){
				if(isStarted){
					NextSent();
				} else {
					NextDialogue();
				}
			}
		}
	}
}
