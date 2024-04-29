using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public float speed;
	public int i;
	public int typer;
	public Transform[] moveSpots;
	public bool Go;
	//public float delayTime;
	//public float curTime;

	void Start(){
		//curTime = delayTime;
	}

	void UpdateCounter(){
		i += typer;
		//curTime = delayTime;
		i = Mathf.Clamp(i, 0, moveSpots.Length - 1);
	}

	void Update(){
		if(Vector3.Distance(transform.position, moveSpots[i].position) < 1f){
			/*
			Debug.Log(curTime);
			if(curTime <= 0){
				UpdateCounter();
			} else{
				curTime = curTime - Time.deltaTime;
			}
			*/
			if(Go){
				UpdateCounter();
			}
		} else {
			transform.position = Vector3.MoveTowards(transform.position, moveSpots[i].position, speed*Time.deltaTime);
		}
	}
}
