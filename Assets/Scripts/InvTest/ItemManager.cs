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
                Flask();
                break;
            case "Snickers":
                Snickers();
                break;
            // �߰����� �����ۿ� ���� ó��
            default:
                Debug.LogError("Unknown item name: " + itemName);
                break;
        }
    }

    private void Flask()
    {
        HPgauge.HP += 10;
    }

    private void Snickers()
    {
        HPgauge.HP += 10;
    }
}

