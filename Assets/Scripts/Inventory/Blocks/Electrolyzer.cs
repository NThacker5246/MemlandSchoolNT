using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrolyzer : MonoBehaviour
{
	[SerializeField] private GameObject Liquid;
	[SerializeField] private GameObject LBP;
	[SerializeField] private Inventory player;
	[SerializeField] private bool inColl;
	[SerializeField] private bool Liq;
	[SerializeField] private bool LB;
	[SerializeField] private ParticleSystem part;
	[SerializeField] private Animator fireShow;
	[SerializeField] private bool isDid;

	void Awake(){
		part.Stop();
		fireShow.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			player = other.GetComponent<Inventory>();
			inColl = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	void Update(){
		if(inColl && Input.GetMouseButtonDown(0)){
			if(player.slots[player.isHOT].transform.childCount > 0) {
				Transform item = player.slots[player.isHOT].transform.GetChild(0);
				if(item.tag == "AlmondWater"){
					Liquid.SetActive(true);
					Liq = true;
					Destroy(item.gameObject);
					
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

				if(item.tag == "LBP"){
					LBP.SetActive(true);
					LB = true;
					Destroy(item.gameObject);
					
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
		if(inColl && Liq && LB && Input.GetKeyDown(KeyCode.E) && !isDid){
			part.Play();
			fireShow.enabled = true;
			fireShow.SetBool("f", true);
			isDid = true;
		}
	}

	public void StopPart(){
		part.Stop();
	}

	public bool isDidF(){
		return isDid;
	} 
}
