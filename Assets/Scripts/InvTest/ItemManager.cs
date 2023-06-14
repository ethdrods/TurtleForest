using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void ExecuteItemFunction(string itemName)
    {
        // �������� �̸��� ���� ������ �Լ��� �����Ͽ� ȣ��
        switch (itemName)
        {
            case "Flask":
                ExecuteFlask();
                break;
            case "ItemB":
                ExecuteItemB();
                break;
            // �߰����� �����ۿ� ���� ó��
            default:
                Debug.LogError("Unknown item name: " + itemName);
                break;
        }
    }

    private void ExecuteFlask()
    {
        
    }

    private void ExecuteItemB()
    {
        // ItemB�� ���� ���� ó��
    }
}
