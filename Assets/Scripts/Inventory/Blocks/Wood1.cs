using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood1 : MonoBehaviour
{
	[SerializeField] private bool inColl;
	[SerializeField] private Inventory player;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
			player = other.GetComponent<Inventory>();
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	void Update(){
		if(Input.GetMouseButtonDown(0) && inColl){
			//int i = 0;
			GameObject slt = player.slots[player.isHOT];
			if(slt.transform.childCount > 0) {
				Transform item = slt.transform.GetChild(0);
				//foreach(Transform item in slt.GetComponent<Transform>()){
				if(item.tag == "axe"){
					player.an.SetBool("isUseAxe", true);
					StartCoroutine("Breaking");
					return;
				}
				//}
			}
		}
	}

	IEnumerator Breaking(){
		yield return new WaitForSeconds(0.5f);
		player.an.SetBool("isUseAxe", false);
		Destroy(gameObject);
	}
}
