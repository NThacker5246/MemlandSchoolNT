using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
	public GameObject Axe;

	void Update()
	{
		if(Axe == null){
			Axe = GameObject.FindGameObjectWithTag("axe");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && Axe != null){
			if(Axe.GetComponent<Use>().used2 == true)
			{
				DstBlk();
				//GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkDwn();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Axe.GetComponent<Use>().used2 = false;
	}

	public void DstBlk()
	{
		Destroy(gameObject);
		Axe.GetComponent<Use>().used2 = false;
		//GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkAttack();
	}
}
