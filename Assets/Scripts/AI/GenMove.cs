using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMove : MonoBehaviour
{
	public bool mov;
	public bool inColl;
	public float l;
	public float speed = 1f;
	public Vector3 temp;

	public void Move1(){
		Vector3 ro = transform.position;
		Vector3 rd = transform.forward + transform.position;

        Ray r = new Ray(ro, rd);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(r, out hit, l)){
        	transform.eulerAngles += new Vector3(0, 1, 0);
        } else {
        	transform.position += transform.forward*speed;
        }

        Debug.DrawLine(ro, rd, Color.red);
	}

	public void Move(){
		if(temp != new Vector3(0,0,0)){
			transform.position -= temp;
			transform.eulerAngles += new Vector3(0,1,0);
		} else {
			transform.position += transform.forward * speed;
		}
	}

	void OnTriggerEnter(Collider other){
		temp = transform.position - other.transform.position;
	}

	void OnTriggerExit(Collider other){
		temp = new Vector3(0,0,0);
	}

	void Update(){
		if(mov){
			Move();
		}
	}
}
