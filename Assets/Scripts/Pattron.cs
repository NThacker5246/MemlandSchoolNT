using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattron : MonoBehaviour
{
	public int velx;
	public float vely;
	public GameObject GmManager;
	public Transform player;
	public Rigidbody rb;
	public bool isGrounded;
	public bool isStopped;
	
	private void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//GmManager.GetComponent<GameManager>().RestartGame();
			return;
		}
		if(other.tag == "ground"){
			isGrounded = true;
		}

		if(other.tag == "DarkEnemy"){
			HP hp = other.GetComponent<HP>();
			hp.Damage(2);
			Destroy(gameObject);
		}
	}

	public void FixedUpdate(){
		if(isGrounded == false){
			Vector3 movement = new Vector3(velx, 0f, vely / Time.deltaTime);
			movement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movement;
			transform.position += movement;
			//rb.AddForce(movement);
		} else {
			Destroy(gameObject);
		}
	}
}
