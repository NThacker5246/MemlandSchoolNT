using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vipravitel : MonoBehaviour
{
	public bool inColl;
	public bool isDid;
	public Inventory player;
	public GameObject VipravitelObj;

	void Start(){
		if(isDid){
			VipravitelObj.SetActive(true);
		}
	}

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
		if(inColl && !isDid){
			if(Input.GetMouseButtonDown(0)){
				Transform slot = player.slots[player.isHOT].transform;
				Transform item = slot.GetChild(0);
				if(item.tag == "vip"){
					VipravitelObj.SetActive(true);
					isDid = true;
					Destroy(item.gameObject);
					//player.isFull[player.isHOT] = false;
					player.ResetBit(player.isHOT);
					if(player.isHOT == player.emp - 1){
						if(player.ful > (short) (player.emp - 1)){
							player.ful = (short) (player.emp - 1);
						}
					} else {
						player.delC += 1;
						if(player.ful > (short) (player.isHOT - 1)) {
							player.ful = (short) (player.isHOT - 1);
						}
					}
					return;
				}
			}
		}
	}
}
