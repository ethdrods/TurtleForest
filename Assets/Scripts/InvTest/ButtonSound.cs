using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button;
    public AudioClip soundClip;
    public AudioSource audioSource;

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �ڵ鷯 ���
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        // ����� �ҽ��� Ŭ�� �Ҵ� �� ���
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
