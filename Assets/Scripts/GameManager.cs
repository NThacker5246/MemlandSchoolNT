using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Inventory inventory;
	public GameObject[] prefs;
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Start(){
		/*
		int[] data = file.InvItems;
		Debug.Log(data);

		for(int i = 0; i < 7; i++){
			for(int j = 0; j < prefs.Length; j++){
				if(data[i] == prefs[j].GetComponent<Spawn>().id){
					Instantiate(prefs[j], inventory.slots[i].transform);
				}
			}
		}
		*/
	}
}
