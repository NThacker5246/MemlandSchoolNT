using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform playerTransform;
	public float speed;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other){
    	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Damage(damage);
        //GameObject.FindGameObjectWithTag("SpBtn").GetComponent<AnimBtn>().anim.SetTrigger("IsTriggered");
    }

    public void spare()
    {
        damage = -1;
    }
}
