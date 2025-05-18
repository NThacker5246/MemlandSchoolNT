using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	[SerializeField] private Inventory inventory;
	public int i;

	private void Update()
	{
		if(transform.childCount <= 0)
		{
			
		}
	}


	public void DropItem()
	{
		if(transform.childCount > 0){
			if(i == inventory.emp - 1){
				//inventory.isFull[i] = false;
				inventory.ResetBit(i);
				Transform child = transform.GetChild(0); 
				child.GetComponent<Spawn>().SpawnDroppedItem();
				inventory.emp -= 1;
				if(inventory.ful > (short) (inventory.emp - 1)){
					inventory.ful = (short) (inventory.emp - 1);
				}
				Destroy(child.gameObject);
			} else {
				inventory.delC += 1;
				//inventory.isFull[i] = false;
				inventory.ResetBit(i);
				Transform child = transform.GetChild(0); 
				child.GetComponent<Spawn>().SpawnDroppedItem();
				if(inventory.ful > (short) (i - 1)) {
					inventory.ful = (short) (i - 1);
				}
				Destroy(child.gameObject);
			}
		}
	}

	public void Throw2Item()
	{
		if(transform.childCount > 0){
			if(i == inventory.emp - 1){
				//inventory.isFull[i] = false;
				inventory.ResetBit(i);
				Transform child = transform.GetChild(0); 
				child.GetComponent<Spawn>().ThrowItem();
				inventory.emp -= 1;
				if(inventory.ful > (short) (inventory.emp - 1)){
					inventory.ful = (short) (inventory.emp - 1);
				}
			} else {
				inventory.delC += 1;
				//inventory.isFull[i] = false;
				inventory.ResetBit(i);
				Transform child = transform.GetChild(0); 
				child.GetComponent<Spawn>().ThrowItem();
				if(inventory.ful > (short) (i - 1)) {
					inventory.ful = (short) (i - 1);
				}
			}
		}
	}
}
