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
            }
        }
    }

    public void Chest()
    {
        inventoryOn = !inventoryOn;
        inventory.SetActive(inventoryOn);
    }
}
