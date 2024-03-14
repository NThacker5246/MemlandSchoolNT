using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
	public int questNumber;
	public int[] items;
	public GameObject[] Clouds;
	//public GameObject barrier;
	public GameObject Coin;
	public GameObject NPC;
	public GameObject drink;
	public string[] questsName;

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("Enter");
		//Debug.Log(questNumber);
		//Debug.Log(other.tag);
		if(other.tag == "Item")
		{
			Debug.Log(other.gameObject.GetComponent<Pickup>().id);
			if(other.gameObject.GetComponent<Pickup>().id == items[questNumber])
			{
				questNumber++;
				Destroy(other.gameObject);
				Debug.Log("pickupped");
				CheckQuests();
			}
		}
	}

	public void CheckQuests()
	{
        for(int i = 0; i < Clouds.Length; i++)
		{
			if(i == questNumber)
			{
				Clouds[i].SetActive(true);
				Clouds[i].GetComponent<Animator>().SetTrigger("isTriggered");
			}
			else
			{
				Clouds[i].SetActive(false);
			}
		}
		if(questNumber == 1)
		{
			Coin.SetActive(true);
		}
	}
}