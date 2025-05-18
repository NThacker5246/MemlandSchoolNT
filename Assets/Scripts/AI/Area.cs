using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
	public Tusovshik tusa;
	public Light dl;
	public GameObject W;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			tusa.Mov = true;
			tusa.Mov1 = true;
			dl.color = new Color32(255, 0, 0, 255);
			W.SetActive(true);
		}
	}
}
