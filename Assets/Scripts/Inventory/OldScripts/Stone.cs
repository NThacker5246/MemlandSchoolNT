using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
	public GameObject Pick;
	//public GameObject ThisBlk;

	void Update()
	{
		if(Pick == null){
			Pick = GameObject.FindGameObjectWithTag("pick");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && Pick != null){
			if(Pick.GetComponent<Use>().used1 == true)
			{
				DstBlk();
				//GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkDwn();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Pick.GetComponent<Use>().used1 = false;
	}

	public void DstBlk()
	{
		Destroy(gameObject);
		Pick.GetComponent<Use>().used1 = false;
		//GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkAttack();
	}
}
