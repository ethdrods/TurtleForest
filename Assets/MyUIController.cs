using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUIController : MonoBehaviour
{
    public GameObject uiObject; // UI ������Ʈ

    public void ShowUI()
    {
        uiObject.SetActive(true);
    }
    public void CloseUI()
    {
        uiObject.SetActive(false);
    }
}
