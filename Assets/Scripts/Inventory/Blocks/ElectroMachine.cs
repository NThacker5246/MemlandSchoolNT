using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroMachine : MonoBehaviour
{
	public Transform circle;
	public float Voltage;
	public bool inColl;
	public float roX;
	public float vx = 1;
	public ParticleSystem part;
	private Rigidbody player;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
			player = other.GetComponent<Rigidbody>();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
    		vx = 1;
    		Voltage = 0;
		}
	}

	void Start(){
		part.Stop();
	}

    // Update is called once per frame
    void Update()
    {
        if(inColl){
        	if(Input.GetKey(KeyCode.E)){
        		roX += vx;
        		vx += 0.1f;
        		Voltage += 0.1f;
        		if(Voltage >= 20f){
        			part.Play();
        			StartCoroutine("p");
        			player.AddForce(player.transform.forward * -200f);
        		}
        	} else if(Input.GetKeyUp(KeyCode.E)){
        		vx = 1;
        		Voltage = 0;
        	}
        }
		circle.eulerAngles = new Vector3(roX, 0, 90);
    }

    IEnumerator p(){
   		yield return new WaitForSeconds(1f);
		part.Stop();	
	}
}
