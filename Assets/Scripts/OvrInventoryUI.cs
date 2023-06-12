using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class OvrInventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
    }

    //slotCnt������ŭ�� ���� Ȱ��ȭ
    private void SlotChange(int val)
    {
        for(int i = 0; i<slots.Length; i++)
        {
            slots[i].slotnum = i;
        }
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Four))//Oculus yŰ
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }


    //���� �ʱ�ȭ&������ ������ŭ ���� ä���
    void RedrawSlotUI()
    {
        for(int i=0; i<slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i=0; i<inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
