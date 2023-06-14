using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

// sealed�� ����Ͽ� �ٸ� Ŭ������ ��ӵ��� ���ϵ��� ��.
public sealed class ItemIO
{
    public static void SaveDate()
    {
        GameObject player = GameObject.Find("Player");
        // �κ��丮���� ������ �������ִ� ����Ʈ�� �޾ƿ´�.
        List<GameObject> item = player.transform.Find("OVRCameraRig/TrackingSpace/Canvas/InventoryUI").gameObject.GetComponent<InventoryTest>().AllSlot;

        XmlDocument XmlDoc = new XmlDocument();             // XML���� ����.
        XmlElement XmlEl = XmlDoc.CreateElement("ItemDB");  // ��� ����.
        XmlDoc.AppendChild(XmlEl);                          // ��Ҹ� XML������ ÷��.

        // ����Ʈ�� �� ũ��(������ ����.)
        int Count = item.Count;

        for (int i = 0; i < Count; i++)
        {
            // ���� ����Ʈ���� ������ �ϳ��� �����´�.
            SlotTest itemInfo = item[i].GetComponent<SlotTest>();

            // ������ ��������� ������ �ʿ䰡 �����Ƿ� �ѱ��.
            if (!itemInfo.isSlots())
                continue;

            // �ʵ�(���)�� ����.
            XmlElement ElementSetting = XmlDoc.CreateElement("Item");

            // �ʵ�(���)�� ������ ����.
            ElementSetting.SetAttribute("SlotNumber", i.ToString());                    // n��° ���Կ� ������.
            ElementSetting.SetAttribute("Name", itemInfo.ItemReturn().Name);            // �������� �̸�.
            ElementSetting.SetAttribute("Count", itemInfo.slot.Count.ToString());       // �������� ����. (ex: �� ���Կ� ������ ������ 10����.)
            ElementSetting.SetAttribute("MaxCount", itemInfo.ItemReturn().MaxCount.ToString()); // �������� ��ĥ�� �ִ� �Ѱ�.
            XmlEl.AppendChild(ElementSetting);                                          // ItemDB��ҿ� ���� ������ ��Ҹ� ������ ÷��.
        }

        // XML������ ��������. ���ڷδ� ������ ������ ���.
        XmlDoc.Save(Application.dataPath + "/Save/InventoryData.xml");
    }


    public static List<GameObject> Load(List<GameObject> SlotList)
    {
        if (!System.IO.File.Exists(Application.dataPath + "/Save/InventoryData.xml"))
            return SlotList;

        XmlDocument XmlDoc = new XmlDocument();                             // ������ ����.
        XmlDoc.Load(Application.dataPath + "/Save/InventoryData.xml");      // ��λ��� XML������ �ε�
        XmlElement Xmlel = XmlDoc["ItemDB"];                                // �Ӽ� ItemDB�� ����.

        foreach (XmlElement ItemElement in Xmlel.ChildNodes)
        {
            // ������ n��° ��ũ��Ʈ�� �����´�.
            SlotTest slot = SlotList[System.Convert.ToInt32(ItemElement.GetAttribute("SlotNumber"))].GetComponent<SlotTest>();

            // ������ ����.
            ItemTest item = new ItemTest();

            // �������� ������ �����Ѵ�.
            string Name = ItemElement.GetAttribute("Name");                              // ������ �̸��� ������.
            int MaxCount = System.Convert.ToInt32(ItemElement.GetAttribute("MaxCount")); // ��ĥ�� �ִ� �Ѱ�.
            item.Init(Name, MaxCount);                                                   // ���� ������ ������ ���� �������� ������ �ʱ�ȭ.

            int Count = System.Convert.ToInt32(ItemElement.GetAttribute("Count"));      // ���Կ� �������� n�� ����ֱ� ���ؼ� ������ ������.
            for (int i = 0; i < Count; i++)
                slot.AddItem(item);
        }

        return SlotList;
    }

}
