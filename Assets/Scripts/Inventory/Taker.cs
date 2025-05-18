using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taker : MonoBehaviour
{
	[SerializeField] private GameObject sel;

	void Update(){
		if(Input.GetMouseButton(1) && sel == null){
			Vector3 ro = transform.position;
	        Vector3 rd = transform.forward*3;
	        Ray r = new Ray(ro, rd);
	        RaycastHit hit = new RaycastHit();
	        if(Physics.Raycast(r, out hit, 3) && hit.collider.tag == "takeable"){
	            sel = hit.collider.gameObject;
	        } else return;
			sel.transform.position = transform.forward*2 + transform.position;
			//sel.transform.LookAt(transform);
		} else if(sel != null && !Input.GetMouseButton(1)) {
			sel = null;
		} else if(Input.GetMouseButton(1) && sel != null){
			sel.transform.position = transform.forward*2 + transform.position;
		}
	}
}
