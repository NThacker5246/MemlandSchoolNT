using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text dialogueText;
	public Text nameText;

	public Animator boxAnim;
	public Animator startAnim;

	private Queue<string> sentences;

	public DialogueTrigger td;

	private void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		boxAnim.SetBool("boxOpen", true);
		startAnim.SetBool("startOpen", false);

		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue(false);
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue(bool isT = true)
	{
		boxAnim.SetBool("boxOpen", false);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>().LockCursor();
		if(!isT){
			td.isStoppedCurrentDialogue = true;
		}
	} 
}
