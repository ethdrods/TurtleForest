using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class RightHandController : MonoBehaviour
{
    public GameObject eq;  // Eq ���� ������Ʈ
    public GameObject handCollider;  // HandCollider ���� ������Ʈ
    public GameObject flask;  // Flask ���� ������Ʈ
    public GameObject compass;  // Compass ���� ������Ʈ

    private int currentItemIndex = 0;  // ���� Ȱ��ȭ�� �������� �ε���

    private void Update()
    {
        // k Ű�� ������ �� ó��
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ActivateNextItem();
        }
    }

    private void ActivateNextItem()
    {
        // ��� �������� ��Ȱ��ȭ
        DeactivateAllItems();

        // ���� �������� Ȱ��ȭ
        switch (currentItemIndex)
        {
            case 0:
                handCollider.SetActive(true);
                break;
            case 1:
                flask.SetActive(true);
                break;
            case 2:
                compass.SetActive(true);
                break;
        }

        // ���� ������ �ε��� ����
        currentItemIndex = (currentItemIndex + 1) % 3;
    }

    private void DeactivateAllItems()
    {
        handCollider.SetActive(false);
        flask.SetActive(false);
        compass.SetActive(false);
    }
}

