using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel; // 설정 메뉴 패널을 참조합니다.

    // 버튼 클릭 시 설정 메뉴 열기/닫기
    public void ToggleSettingsMenu()
    {
        bool isActive = settingsPanel.activeSelf;
        settingsPanel.SetActive(!isActive); // 메뉴가 활성화/비활성화 됩니다.
    }
}

