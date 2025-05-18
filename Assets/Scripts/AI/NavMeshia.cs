using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshia : MonoBehaviour
{
    // Положение точки назначения
    [SerializeField] private Transform goal;
    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    private float tmr;
    void Start()
    {
        // Получение компонента агента
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Указаие точки назначения
    }

    void Update(){
    	if(tmr - 0.5f >= 0f){
    		tmr = 0;
        	agent.destination = goal.position;
    	}
    	tmr += Time.deltaTime;
    }
}
