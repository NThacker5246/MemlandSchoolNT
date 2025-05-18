using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Tusovshik : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    public bool IsENEMY;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool Mov; 
    public bool Mov1; 
    public int hp = 100;
    public bool dd;

    void Start(){
        // Получение компонента агента
    	goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    	agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void FixedUpdate()
    {
    	if(Mov){
	        // Указаие точки назначения
    	    agent.destination = goal.position;
        }

        if(hp <= 0){
            //Anim
            Mov = false;
            dd = true;

        }
    }

    void OnTriggerEnter(Collider other){
    	if(other.tag == "player" && IsENEMY == true){
    		//goal.gameObject.GetComponent<PlayerHealth>().Damage(1);
    		print("Hello, there!");
    	}

        if(other.tag == "bul"){
            hp -= 2;
        }
    }
}