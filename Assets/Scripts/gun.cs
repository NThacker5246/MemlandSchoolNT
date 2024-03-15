using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public GameObject pat;
    public Transform tr;

    public void Start(){
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Shoot(){
    	//Vector3 tr1 = new Vector3(tr.position.x, tr.position.y, tr.position.z);
    	Instantiate(pat, tr.position, Quaternion.Euler(tr.eulerAngles));
    }

    private void OnMouseDown(){
    	Debug.Log("click");
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Shoot();
            Debug.Log("Shot");
        }
    }
}
