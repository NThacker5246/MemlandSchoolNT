using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone1 : MonoBehaviour
{
	public bool inColl;
	public Inventory player;

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
			int i = 0;
			GameObject slt = player.slots[player.isHOT];
			foreach(Transform item in slt.GetComponent<Transform>()){
				if(item.tag == "pick"){
					Destroy(gameObject);
					return;
				}
			}
		}
	}
}
