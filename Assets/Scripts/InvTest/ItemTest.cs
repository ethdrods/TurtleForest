using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public enum TYPE {
        Equipment,
        Supplies,
        Etc
}

    public TYPE type;           // �������� Ÿ��.
    public Sprite DefaultImg;   // �⺻ �̹���.
    public int MaxCount;        // ��ĥ�� �ִ� �ִ� ����.  

    // �κ��丮�� �����ϱ� ���� ����.
    private InventoryTest Iv;
    public string Name;         // �������� �̸�.

    public void Init(string Name, int MaxCount)
    {
        // �̸��� ���� Ÿ���� ����.
        switch (Name)
        {
            case "Equipment": type = TYPE.Equipment; break;
            case "Supplies": type = TYPE.Supplies; break;
            case "Etc": type = TYPE.Etc; break;
        }

        this.Name = Name;           // �̸��� �ʱ�ȭ.
        this.MaxCount = MaxCount;   // ��ĥ�� �ִ� �Ѱ� ������ �ʱ�ȭ.

        

        /*Sprite[] spr = ObjManager.Call().spr;       // �̹��� �迭�� �����´�.
        int Count = ObjManager.Call().spr.Length;   // �̹��� �迭�� �� ũ��.
                                                    // �̹����� �̸��� �������� �̸��� ��.
        for (int i = 0; i < Count; i++)
        {
            // �� �̸��� ������ �� �̹����� DefaultImg�� ����.
            if (spr[i].name == this.Name)
            {
                DefaultImg = spr[i];
                break;
            }
        }*/
    }

    void Awake()
    {
        // �±׸��� "Inventory"�� ��ü�� GameObject�� ��ȯ�Ѵ�.
        // ��ȯ�� ��ü�� ������ �ִ� ��ũ��Ʈ�� GetComponent�� ���� �����´�.
        Iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryTest>();

    }

    void AddItem()
    {
        // ������ ȹ�濡 ������ ���.
        if (!Iv.AddItem(this))
            Debug.Log("�������� ���� á���ϴ�.");
        else
        {
            gameObject.SetActive(false); // ������ ȹ�濡 ������ ���.
            // // �������� ��Ȱ��ȭ �����ش�.
        }

    }

    // �浹üũ
    private void OnTriggerStay(Collider collision)
    {
        float SecIndexTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float SecHandTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        if (SecIndexTrigger != 0.0f)
        {
            Debug.Log("SecondaryIndexTrigger = " + SecIndexTrigger);
            Debug.Log("SecondaryHandTrigger = " + SecHandTrigger);
            // �÷��̾� hand�� �浹�ϸ�.
            if (collision.gameObject.layer == 7)
                AddItem();
        }
    }

    /*public bool Use()
    {
        bool isUsed = false;
        foreach (ItemEffect eft in efts) //�ݺ����� ������ efts�� ExecuteRole ����
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed; //������ ��� �������� ��ȯ
    }*/
}
