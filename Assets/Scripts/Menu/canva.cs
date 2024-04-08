using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canva : MonoBehaviour
{
	public GameObject cnva;
	public bool flag = true;
	public void Update(){
		if(Input.GetKeyDown(KeyCode.F1)){
			cnva.SetActive(!flag);
			flag = !flag;
		}
	}
}
