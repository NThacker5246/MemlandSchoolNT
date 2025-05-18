using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeAIController : MonoBehaviour
{
	public Patrol MovementAI;
	public bool isUp ;
	public DiaMan dm;
	public bool ToMovePortal;
	public Button1 btn;
	public SaveToFile sv;
	public int level;
	public DiaToMove[] chapters;
	public int c;
	public Tusovshik ft;
	public bool ToGo;
	public bool isEnded;
	private bool isStartedloop = true;
	[SerializeField] private Electrolyzer elec;
	[SerializeField] private GameObject Pockerface;

	void Start(){
		if(level == 1 && !(sv.v1.isDid && sv.v2.isDid)){
			MovementAI.Go = false;
			MovementAI.i = 0;
			isUp = true;
		}

		c = sv.c;
	}

	public void Update(){
		if(dm.isStCD && !ToMovePortal){
			dm.isStCD = false;
			MovementAI.Go = true;
			StartCoroutine("reset");
		}

		for(int k = 0; k < chapters[sv.c].patrols.Length; k++){ //3, 16, 17 || 1, 4
			if(MovementAI.i == chapters[sv.c].patrols[k] && !isUp){
				if(isStartedloop){
					isUp = true;
					isStartedloop = false;
					return;
				}
				MovementAI.Go = false;
				if(level != 1 || (sv.v1.isDid && sv.v2.isDid)){
					dm.i++;
					isUp = true;
				}
			}
		}

		if(level == 0) {
			if(MovementAI.i == 17 && !isUp){
				ToMovePortal = true;
			} else if(ToMovePortal && !isUp){
				if(btn.isDid == true){
					StartCoroutine("Go");
					Debug.Log("Going");
					ToMovePortal = false;
					isEnded = true;
				}
			}

			if(MovementAI.i == 28 && c == 2 && elec.isDidF()){
				dm.i = 3;
			}

			if(dm.i == 3 && dm.j == 1){
				Pockerface.SetActive(true);
			}
		}

		if(ft != null){
			if(ft.Mov1){
				dm.i++;
				isUp = true;
				ft.Mov1 = false;
				dm.i = 4;
			}
			if(ft.dd){
				isUp = true;
				dm.i = 5;
				ft.dd = false;
				MovementAI.typer = -1;
				ToMovePortal = false;
				ToGo = true;
			}
		} 

		if(MovementAI.i == 0 && ToGo){
			dm.i = 6;
			isUp = true;
			isEnded = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "pt"){
			gameObject.SetActive(false);
		}
	}

	IEnumerator reset(){
		yield return new WaitForSeconds(1f);
		isUp = false;
	}

	IEnumerator Go(){
		yield return new WaitForSeconds(10f);
		MovementAI.Go = true;
	}
}
