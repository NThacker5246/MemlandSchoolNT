using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
	public Transform parent;
	public Transform[] moveSpots;

	void Start(){
		byte i = 0;
		foreach(Transform child in parent){
			moveSpots[i] = child;
			i += 1;
		}
	}
	
}
