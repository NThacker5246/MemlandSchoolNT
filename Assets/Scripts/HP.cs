using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
	public int healthppint;

	public void Damage(int power){
		healthppint -= power;
		if(healthppint <= 0){
			if(transform.tag != "Player"){
				Destroy(gameObject);
			}
		}
	}

	public void Heal(int st){
		healthppint += st;
	}


}