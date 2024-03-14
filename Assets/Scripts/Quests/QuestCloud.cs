using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCloud : MonoBehaviour
{
	public Animator[] clouds;

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			foreach(Animator anim in clouds)
			{

				anim.SetTrigger("isTriggered");
			}
		}
	}

		public void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			foreach(Animator anim in clouds)
			{

				anim.SetTrigger("isTriggered");
			}
		}
	}
}
