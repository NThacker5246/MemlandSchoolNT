using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	public Inventory inventory;
	public int i;
	public VectorValue save;

	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	private void Update()
	{
		if(transform.childCount <= 0)
		{
			inventory.isFull[i] = false;
		}
	}

	public void DropItem()
	{
		foreach(Transform child in transform)
		{
			child.GetComponent<Spawn>().SpawnDroppedItem();
			GameObject.Destroy(child.gameObject);
		}
	}

	public void Save(){
		foreach(Transform child in transform)
		{
			save.Inventory[i] = child.gameObject;
		}
	}

	public void Load(){
		foreach(Transform child in transform)
		{
			GameObject gm = save.Inventory[i];
			Instantiate(gm, inventory.slots[i].transform);
		}
	}
}
