using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
	private Animator anim;
	[SerializeField] private int levelToLoad;
	[SerializeField] private MemeAIController Trollface;
	[SerializeField] private SaveToFile sv;

	//public GameObject[] prefs;

	//public Vector3 position;
	//public VectorValue playerStorage;
	//private Inventory inv;
	private void Start(){
		anim = GetComponent<Animator>();
		//inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	public void FadeToLevel(){
		SceneManager.LoadScene(levelToLoad);
		anim.SetTrigger("fade");
	}
	public void OnFadeComplete(){
		/*
			playerStorage.initalValue = position;
			GameObject[] slots = inv.slots;
			foreach(GameObject slot in slots) {
				foreach(Transform child in slot.transform){
					Debug.Log(child.gameObject);
					foreach(GameObject pref in prefs){
						if(pref.GetComponent<Use>() == child.gameObject.GetComponent<Use>()){
							playerStorage.Inventory[slot.GetComponent<Slot>().i] = child.gameObject;
						}
					}
				}			
			}
		*/
		if(Trollface.isEnded){
			sv.c += 1;
			sv.CreateState(true);
		}
		SceneManager.LoadScene(levelToLoad);
	}
}