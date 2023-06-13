using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{

    // ����
    public List<GameObject> AllSlot;    // ��� ������ �������� ����Ʈ.
    public RectTransform InvenRect;     // �κ��丮�� Rect
    public GameObject OriginSlot;       // �������� ����.

    public float slotSize;              // ������ ������.
    public float slotGap;               // ���԰� ����.
    public float slotCountX;            // ������ ���� ����.
    public float slotCountY;            // ������ ���� ����.

    // �����.
    private float InvenWidth;           // �κ��丮 ���α���.
    private float InvenHeight;          // �ι��丮 ���α���.
    private float EmptySlot;            // �� ������ ����.



    void Awake()
    {
        // �κ��丮 �̹����� ����, ���� ������ ����.
        InvenWidth = (slotCountX * slotSize) + (slotCountX * slotGap) + slotGap;
        InvenHeight = (slotCountY * slotSize) + (slotCountY * slotGap) + slotGap;

        // ���õ� ������� ũ�⸦ ����.
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, InvenWidth); // ����.
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, InvenHeight);  // ����.

        // ���� �����ϱ�.
        for (int y = 0; y < slotCountY; y++)
        {
            for (int x = 0; x < slotCountX; x++)
            {
                // ������ �����Ѵ�.
                GameObject slot = Instantiate(OriginSlot) as GameObject;
                // ������ RectTransform�� �����´�.
                RectTransform slotRect = slot.GetComponent<RectTransform>();
                // ������ �ڽ��� �����̹����� RectTransform�� �����´�.
                RectTransform item = slot.transform.GetChild(0).GetComponent<RectTransform>();

                slot.name = "slot_" + y + "_" + x; // ���� �̸� ����.
                slot.transform.parent = transform; // ������ �θ� ����. (Inventory��ü�� �θ���.)

                // ������ ������ ��ġ �����ϱ�.
                slotRect.localPosition = new Vector3((slotSize * x) + (slotGap * (x + 1)),
                                                   -((slotSize * y) + (slotGap * (y + 1))),
                                                      0);

                // ������ �ڽ��� �����̹����� ������ �����ϱ�.
                slotRect.localScale = Vector3.one;
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize); // ����
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);   // ����.

                // ������ ������ �����ϱ�.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize - slotSize * 0.3f); // ����.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize - slotSize * 0.3f);   // ����.

                // ����Ʈ�� ������ �߰�.
                AllSlot.Add(slot);
            }
        }

        // �� ���� = ������ ����.
        EmptySlot = AllSlot.Count;
        Invoke("Init", 0.01f);

        void Init()
        {
            ItemIO.Load(AllSlot);
        }
    }

    // �������� �ֱ����� ��� ������ �˻�.
    public bool AddItem(ItemTest item)
    {
        // ���Կ� �� ����.
        int slotCount = AllSlot.Count;

        // �ֱ����� �������� ���Կ� �����ϴ��� �˻�.
        for (int i = 0; i < slotCount; i++)
        {
            // �� ������ ��ũ��Ʈ�� �����´�.
            SlotTest slot = AllSlot[i].GetComponent<SlotTest>();

            // ������ ��������� ���.
            if (!slot.isSlots())
                continue;

            // ���Կ� �����ϴ� �������� Ÿ�԰� �������� �������� Ÿ���� ����.
            // ���Կ� �����ϴ� �������� ��ĥ�� �ִ� �ִ�ġ�� �����ʾ��� ��. (true�� ��)
            if (slot.ItemReturn().type == item.type && slot.ItemMax(item))
            {
                // ���Կ� �������� �ִ´�.
                slot.AddItem(item);
                return true;
            }
        }

        // �� ���Կ� �������� �ֱ����� �˻�.
        for (int i = 0; i < slotCount; i++)
        {
            SlotTest slot = AllSlot[i].GetComponent<SlotTest>();

            // ������ ������� ������ ���
            if (slot.isSlots())
                continue;

            slot.AddItem(item);
            return true;
        }

        // ���� ���ǿ� �ش�Ǵ� ���� ���� �� �������� ���� ����.
        return false;
    }
}
