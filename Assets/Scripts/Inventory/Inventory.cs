using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public int isHOT;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    public Animator an;

    private void Start()
    {
        inventoryOn = false;
        // Здесь можно добавить код предварительной загрузки
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItemAtHotSlot();
            //CheckAnimation();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //UseItemInHotSlot();
            GameObject slt = slots[isHOT];
            foreach(Transform child in slt.transform){
                if(child.tag == "bottle1"){
                    Spawn sp = child.GetComponent<Spawn>();
                    sp.ThrowItem();
                    //CheckAnimation();
                }
            }
        }

        CheckHotkeyInput();
        CheckAnimation();
    }

    private void DropItemAtHotSlot()
    {
        slots[isHOT].GetComponent<Slot>().DropItem();
    }
    /*

    private void UseItemInHotSlot()
    {
        Transform element = slots[isHOT].transform;
        foreach (Transform el in element)
        {
            el.gameObject.GetComponent<Use>().use();
        }
    }
    */

    private void CheckHotkeyInput()
    {
        for (int i = 1; i <= 7; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                isHOT = i - 1;
                //CheckAnimation();
                
            }
        }
    }

    private void CheckAnimation(){
        int j = 0;
        foreach(Transform item in slots[isHOT].transform){
            if(item.tag == "pick"){
                an.SetBool("inHandPick", true);
                an.SetBool("inHandAxe", false);
                an.SetBool("inHandCard", false);
                an.SetBool("inHandGun", false);
                an.SetBool("inbot", false);
            } else if(item.tag == "axe"){
                an.SetBool("inHandPick", false);
                an.SetBool("inHandAxe", true);
                an.SetBool("inHandCard", false);
                an.SetBool("inHandGun", false);
                an.SetBool("inbot", false);
            } else if(item.tag == "Card"){
                an.SetBool("inHandPick", false);
                an.SetBool("inHandAxe", false);
                an.SetBool("inHandCard", true);
                an.SetBool("inHandGun", false);
                an.SetBool("inbot", false);
            } else if(item.tag == "Gun"){
                an.SetBool("inHandPick", false);
                an.SetBool("inHandAxe", false);
                an.SetBool("inHandCard", false);
                an.SetBool("inHandGun", true);
                an.SetBool("inbot", false);
            }  else if(item.tag == "bottle1"){
                an.SetBool("inHandPick", false);
                an.SetBool("inHandAxe", false);
                an.SetBool("inHandCard", false);
                an.SetBool("inHandGun", false);
                an.SetBool("inbot", true);
            } else {
                an.SetBool("inHandPick", false);
                an.SetBool("inHandAxe", false);
                an.SetBool("inHandCard", false);
                an.SetBool("inHandGun", false);
                an.SetBool("inbot", false);
            }
            j += 1;
        }

        if(j == 0){
            an.SetBool("inHandPick", false);
            an.SetBool("inHandAxe", false);
            an.SetBool("inHandCard", false);
            an.SetBool("inHandGun", false);
            an.SetBool("inbot", false);
        }
    }

    public void Chest()
    {
        inventoryOn = !inventoryOn;
        inventory.SetActive(inventoryOn);
    }
}
