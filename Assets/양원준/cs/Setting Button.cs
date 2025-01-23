using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel; // ���� �޴� �г��� �����մϴ�.

    // ��ư Ŭ�� �� ���� �޴� ����/�ݱ�
    public void ToggleSettingsMenu()
    {
        bool isActive = settingsPanel.activeSelf;
        settingsPanel.SetActive(!isActive); // �޴��� Ȱ��ȭ/��Ȱ��ȭ �˴ϴ�.
    }
}

