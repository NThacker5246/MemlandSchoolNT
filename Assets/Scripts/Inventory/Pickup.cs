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
    public short num;
    public short num2 = 1000;


    private void Start()
    {
    	inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        sv = GameObject.FindGameObjectWithTag("sv").GetComponent<SaveToFile>();
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "Player" && !ignore){
            if(inventory.delC == 0){
                //inventory.isFull[inventory.emp] = true;
                inventory.SetBit(inventory.emp);
                GameObject gm = Instantiate(slotButton, inventory.slots[inventory.emp].transform);
                inventory.emp += 1;
                inventory.ful = (short) (inventory.emp - 1);
                sv.its[num] = null;
                sv.Check();
                gm.GetComponent<Spawn>().sv = sv;
                Destroy(gameObject);
                return;
            } else {
                for(; inventory.ful < inventory.emp; inventory.ful += 1){
                    print(inventory.ful);
                    if(inventory.ful >= 0) {
                        //if(!inventory.isFull[inventory.ful]){
                        if(!inventory.IsSetBit(inventory.ful)){
                            //inventory.isFull[inventory.ful] = true;
                            inventory.SetBit(inventory.ful);
                            GameObject gm = Instantiate(slotButton, inventory.slots[inventory.ful].transform);
                            inventory.delC -= 1;
                            sv.its[num] = null;
                            sv.Check();
                            gm.GetComponent<Spawn>().sv = sv;
                            Destroy(gameObject);
                            return;
                        }
                    }
                }
            }
        } else {
            if(num2 == 0){
                ignore = false;
                num2 = 1;
                return;
            } else {
                num2 -= 1;
            }
        }
    }

    /*
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
    */
}
