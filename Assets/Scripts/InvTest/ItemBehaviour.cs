using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private GameObject item;
    private SlotTest slotTest;
    private string defaultImageName;
    

    private void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void init()
    {
        // SlotTest ��ü�� ���� ��������
        slotTest = GetComponent<SlotTest>();


        if (slotTest != null)
        {
            // SlotTest ��ũ��Ʈ�� DefaultImg�� �̸� ��������
            defaultImageName = slotTest.GetDefaultImageName();
            Debug.Log("DefaultImg�� �̸�: " + defaultImageName);

            item = Resources.Load<GameObject>(defaultImageName);
            if (item == null)
            {
                Debug.Log("Could not find prefeb! " + defaultImageName);
            }
        }
    }

    public void UseItem()
    {
        Component scriptComponent = item.GetComponent<Component>();

    }
}
