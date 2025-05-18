using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
	[SerializeField] private bool inColl;
	[SerializeField] private bool flag;
	[SerializeField] private Animator anim;
	[SerializeField] private Inventory player;

	private void Start(){
		anim = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
			player = other.GetComponent<Inventory>();
		}
	}

	private void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	private void Update(){
		if(Input.GetMouseButtonDown(0) && inColl){
			GameObject Slot = player.slots[player.isHOT];
			if(Slot.transform.childCount > 0) {
				Transform item = Slot.transform.GetChild(0);
				//foreach(Transform item in Slot.transform){
				if(item.tag == "Card"){
					player.an.SetBool("isUseCard", true);
					StartCoroutine("Opn");
					flag = !flag;
					anim.SetBool("Door", flag);
				}
			}
			//}
		}
	}

	IEnumerator Opn(){
		yield return new WaitForSeconds(0.8333f);
		player.an.SetBool("isUseCard", false); 
	}
}
