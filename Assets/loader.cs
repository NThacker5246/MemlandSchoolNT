using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour
{
	public portal portal;
	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			portal.FadeToLevel();
		}
	}
}
