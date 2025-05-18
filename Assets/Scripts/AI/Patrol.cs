using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public float speed;
	public int i;
	public int typer;
	public Transform[] moveSpots;
	public DotsInLevel[] dt;
	public SaveToFile sv;
	public bool Go;
	[SerializeField] private bool frame;
	[SerializeField] private float RestrictMov;
	//public float delayTime;
	//public float curTime;

	void Start(){
		//curTime = delayTime;
	}

	void UpdateCounter(){
		i += typer;
		//curTime = delayTime;
		i = Mathf.Clamp(i, 0, dt[sv.c].moveSpots.Length - 1);
	}

	void Update(){
		if(!frame){
			if(dt[sv.c].moveSpots.Length == 0){
				gameObject.SetActive(false);
				print("This if");
			} else {
				transform.position = dt[sv.c].moveSpots[i].position;
				print($"This else {sv.c}");
			}
			frame = true;
		}

		print(Vector3.Distance(transform.position, dt[sv.c].moveSpots[i].position));
		print(i);

		if(Vector3.Distance(transform.position, dt[sv.c].moveSpots[i].position) <= RestrictMov){
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

			print(true);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, dt[sv.c].moveSpots[i].position, speed*Time.deltaTime);
		}
	}
}

[System.Serializable]
public class DotsInLevel 
{
	public Transform[] moveSpots;
}