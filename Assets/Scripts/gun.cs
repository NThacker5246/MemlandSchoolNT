using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public GameObject pat;
    public void Shoot(){
    	Transform tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    	Vector3 tr1 = new Vector3(tr.position.x, tr.position.y, tr.position.z);
    	Transform ts = pat.GetComponent<Transform>();
    	ts.eulerAngles = new Vector3(0f, tr.eulerAngles.y, 0f);
    	ts.position = tr1;
    	Instantiate(pat, Quaternion.Euler(tr.eulerAngles)*tr1, Quaternion.Euler(tr.eulerAngles));
    }

    private void OnMouseDown(){
    	Debug.Log("click");
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }
}
