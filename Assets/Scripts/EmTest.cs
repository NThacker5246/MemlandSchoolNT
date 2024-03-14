/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmTest : MonoBehaviour
{
	public float speed;
	private Transform target;
	public float stopDist;
	public float retaDist;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Vector3.Distance(transform.position, target.position) > stopDist){
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
		} else if(Vector3.Distance(transform.position, target.position) < stopDist && Vector3.Distance(transform.position, target.position) > retaDist){
			transform.position = this.transform.position;
		} else if(Vector3.Distance(transform.position, target.position) < retaDist){
			transform.position = Vector3.MoveTowards(transform.position, target.position, -speed*Time.deltaTime);
		}
	}
}
*/
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class EmTest : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    public bool IsENEMY;

    void FixedUpdate()
    {
    	goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // Получение компонента агента
        UnityEngine.AI.NavMeshAgent agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Указаие точки назначения
        agent.destination = goal.position;
    }

    private void OnTriggerEnter(Collider other){
    	if(other.tag == "player" && IsENEMY == true){
    		goal.gameObject.GetComponent<PlayerHealth>().Damage(1);
    	}
    }
}