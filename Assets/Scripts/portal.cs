using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
	private Animator anim;
	public int levelToLoad;
	public GameObject[] prefs;

	public Vector3 position;
	public VectorValue playerStorage;
	private Inventory inv;
	private void Start(){
		anim = GetComponent<Animator>();
		inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	public void FadeToLevel(){
		anim.SetTrigger("fade");
	}
	public void OnFadeComplete(){
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
		SceneManager.LoadScene(levelToLoad);
	}
}