using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public double health;
	private void Update()
	{
		if(health <= 0){
    		FindObjectOfType<GameManager>().RestartGame();
    	}
	}

	public void Damage(float damage)
	{
		health = health - damage;
	}

	public void Heal()
	{
		health = health + 100;
	}
}
