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
        }

        if (Input.GetMouseButtonDown(0))
        {
            //UseItemInHotSlot();
        }

        CheckHotkeyInput();
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
                foreach(Transform item in slots[isHOT].transform){
                    if(item.tag == "pick"){
                        an.SetBool("inHandPick", true);
                        an.SetBool("inHandAxe", false);
                        an.SetBool("inHandCard", false);
                    } else if(item.tag == "axe"){
                        an.SetBool("inHandPick", false);
                        an.SetBool("inHandAxe", true);
                        an.SetBool("inHandCard", false);
                    } else if(item.tag == "Card"){
                        an.SetBool("inHandPick", false);
                        an.SetBool("inHandAxe", false);
                        an.SetBool("inHandCard", true);
                    } else {
                        an.SetBool("inHandPick", false);
                        an.SetBool("inHandAxe", false);
                        an.SetBool("inHandCard", false);
                    }
                }
            }
        }
    }

    public void Chest()
    {
        inventoryOn = !inventoryOn;
        inventory.SetActive(inventoryOn);
    }
}
