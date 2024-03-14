using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestShow : MonoBehaviour
{
	public Text[] questTexts;

	public void full()
	{
		for(int i = 0; i < questTexts.Length; i++){
			questTexts[i].text = GameObject.FindGameObjectWithTag("NPC").GetComponent<Quests>().questsName[i];
		}
	}
}
