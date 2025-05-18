using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DialogDataSet {
	public MemeController authory;
	[TextArea(3, 10)]
	public string text;
	public int[] nextSenteces;
	public int[] nextActions;
}

public class HackerDialogue :MonoBehaviour
{
	[SerializeField] private DialogDataSet[] set;
	[SerializeField] private int sentece;
	[SerializeField] private int nextAction;
	[SerializeField] private Actions[] acts = new Actions[3];

	public void GoNextSentece(int next) {
		int prev = sentece;
		sentece = set[sentece].nextSenteces[next];
		acts[nextAction]();
		nextAction = set[prev].nextActions[next];
	}

	[System.Serializable]
	private delegate void Actions();

	private static void Act1(){
		print("Test");
	}

	private static void Act2(){
		print("Said");
	}

	private static void Act3(){
		print("Setup");
	}


	void Awake(){
		acts[0] = Act1;
		acts[1] = Act2;
		acts[2] = Act3;
	}
}
