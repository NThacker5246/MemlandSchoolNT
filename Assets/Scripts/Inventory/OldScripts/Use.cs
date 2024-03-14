using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
	private Inventory inventory;
	public GameObject Enemy;

	public GameObject Stone;
	public GameObject Wood;
	//private Animator swan;
	public GameObject drink;
	public bool used;
	public bool used1;
	public bool used2;

	public string typeItem;
	public string typeDrink;

	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	private void Update()
	{
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		Stone = GameObject.FindGameObjectWithTag("Stone");
		Wood = GameObject.FindGameObjectWithTag("Wood");
		
	}

	public void use()
	{
		if(typeItem == "sword")
		{
			//swan.SetBool("isAtt", true);
			GameObject.Destroy(Enemy);
			//swan.SetBool("isAtt", false);
		}
		else if(typeItem == "drink"){
			if(typeDrink == "Heal"){
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Heal();
				GameObject.Destroy(drink);
			}

			else if(typeDrink == "Jump"){
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().JumpForc(5);
				GameObject.Destroy(drink);
			}

			else if(typeDrink == "Speed"){
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SpeedForc(5);
				GameObject.Destroy(drink);
			}
		}
		else if(typeItem == "Wand"){
			used = true;
		}

		else if(typeItem == "Pickaxe" || typeItem == "Axe") {
			if (typeItem == "Pickaxe") {
				used1 = true;
			} else if (typeItem == "Axe") {
				used2 = true;
			}
		}

		else if(typeItem == "Gun") {
			GetComponent<gun>().Shoot();
			Debug.Log("DID");
		}
		
	}
	
}
