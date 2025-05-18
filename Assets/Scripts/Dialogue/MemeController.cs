using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeController :MonoBehaviour {
	[SerializeField] private byte name;
	[SerializeField] private byte state;

	public void WriteAction(){
		print("inout");
	}
}