using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            //ChangeVolumeZero(); -> �̷��� �ٽ� �������Ⱑ �����. �׳� �Ʒ� ����� ���� �� ������?
            AudioListener.pause = true;
            //�̷��� �Ǹ� ��ü ������ 0�ɰ� ����. �ٵ� �ؿ��� �Ȱ��� �ѵ�...
            //��������̶� ȿ�����̶� �ͼ��� ���� �γ�? �ϴ� �˷��ش�� �غ���
            Save();
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
}
