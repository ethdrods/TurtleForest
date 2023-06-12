using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab; // ������ ��ü�� ������
    private bool hasSpawned = false;

    private void Start()
    {
        if (!hasSpawned)
        {
            SpawnObject();
            hasSpawned = true;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 1.0f; // Ư�� ������Ʈ�κ��� 1.0f ������ ��ġ ���
        Instantiate(prefab, spawnPosition, Quaternion.identity); // ��ü ����
    }
}
