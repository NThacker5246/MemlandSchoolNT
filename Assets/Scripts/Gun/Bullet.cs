using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float As;
	public float Damage;
	public Rigidbody rb;
	public Collider col;

	void Start(){
		rb = GetComponent<Rigidbody>();
		Vector3 startMove = Quaternion.Euler(transform.eulerAngles) * new Vector3(0, 0, 100*As);
		rb.AddForce(startMove);
		StartCoroutine("resetGun");
	}

	IEnumerator resetGun(){
		yield return new WaitForSeconds(0.005f);
		col.isTrigger = false;
	}
}
