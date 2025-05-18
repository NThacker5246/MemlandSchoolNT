using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNext : MonoBehaviour
{
	[SerializeField] private Transform nextLevel;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.transform.position = nextLevel.position;
		}
	}
}
