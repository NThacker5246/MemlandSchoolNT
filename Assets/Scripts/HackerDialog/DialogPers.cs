using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPers : MonoBehaviour
{
	[SerializeField] private DiaDt[] replica;
	[SerializeField] private int id;
	[SerializeField] private int cn;
	[SerializeField] private Text tx;
	[SerializeField] private Animator dB;
	public bool Locked;

	void Update(){
		if(Input.GetKey(KeyCode.C)){
			if(cn == replica[id].sent.Length && !Locked){
				for(int i = 0; i < replica[id].numNext.Length; i++){
					if(Input.GetKeyDown(KeyCode.Alpha1 + i)){
						cn = 0;
						id = replica[id].numNext[i];
						break;
					}
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.C)){
			if(cn == 0) dB.SetBool("boxOpen", true);
			if(cn < replica[id].sent.Length){
				tx.text = replica[id].sent[cn];
				cn++;
			} else if(cn == replica[id].sent.Length){
				dB.SetBool("boxOpen", false);
			}
		}
	}
}

[System.Serializable]
public class DiaDt {
	[TextArea(3, 10)]
	public string[] sent;
	public int[] numNext;
}
