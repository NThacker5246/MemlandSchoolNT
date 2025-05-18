using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chem : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private bool inColl;
	[SerializeField] private ParticleSystem part;
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
		}
	}

	void Start(){
		part.Stop();
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if(inColl){
        	if(Input.GetKeyDown(KeyCode.E)){
    			StartCoroutine("p");
        	}
        }
    }

    IEnumerator p(){
    	anim.SetBool("Chem", true);
   		yield return new WaitForSeconds(1.1f);
    	anim.SetBool("Chem", false);
		player.AddForce(player.transform.forward * -1000f);
		part.Play();
   		yield return new WaitForSeconds(1f);
		part.Stop();	
	}
}

//Chem