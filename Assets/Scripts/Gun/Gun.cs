using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	public GameObject bullet;
	public Transform fcam;
	public int ammo;
	public Text am;

	void Start(){
		fcam = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update(){
		if(Input.GetMouseButtonDown(0) && ammo > 0){
			Inventory inv = fcam.GetComponent<Inventory>();
			Transform slot = inv.slots[inv.isHOT].transform;
			foreach(Transform item in slot){
				if(item.tag == "Gun"){
					GameObject gm = Instantiate(bullet, fcam.position, Quaternion.Euler(fcam.eulerAngles));
					ammo -= 1;
					return;
				}
			}
		}
		/*
			string str = $"Ammo: {ammo}";
			if(am.text != str){
				am.text = str;
			}
		*/
	}
}
