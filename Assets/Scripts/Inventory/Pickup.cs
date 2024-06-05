using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public bool ignore;
    public int id;
    public SaveToFile sv;
    private int num = 1;


    private void Start()
    {
    	inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        sv = GameObject.FindGameObjectWithTag("sv").GetComponent<SaveToFile>();
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player") && !ignore)
    	{

    		for(int i = 0; i < inventory.slots.Length; i++)
    		{
    			if(inventory.isFull[i] == false)
    			{
    				inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
    				Destroy(gameObject);
    				break;
    			}
    		}
    	} else {
            if(num == 0){
                ignore = false;
                num = 1;
                return;
            } else {
                num -= 1;
            }
        }
    }
}
