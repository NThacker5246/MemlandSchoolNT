using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public GameObject Wand;
	public GameObject ThisBlk;

	void Update()
	{
		Wand = GameObject.FindGameObjectWithTag("wand");
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && Wand != null){
			if(Wand.GetComponent<Use>().used == true)
			{
				DstBlk();
				GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkDwn();
			}
		}
	}

	public void DstBlk()
	{
		Destroy(ThisBlk);
		Wand.GetComponent<Use>().used = false;
		GameObject.FindGameObjectWithTag("Player").GetComponent<wandAnim>().blkAttack();
	}
}
