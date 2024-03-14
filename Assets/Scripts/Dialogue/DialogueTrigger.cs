using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue[] dialogue;

	public int Count;

	public void TriggerDialogue()
	{
		Count++;
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue[Count]);
	}
}
