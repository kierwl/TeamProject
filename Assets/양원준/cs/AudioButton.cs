using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioButton : MonoBehaviour
{

    public Slider volumeSlider;
    public Button toggleButton;  // �����̴� Ȱ��ȭ/��Ȱ��ȭ ��ư

    void Start()
    {
        // �����̴��� �ʱ� ���� ���� ������ �°� ����
        volumeSlider.value = AudioListener.volume;

        // �����̴� ���� ����� ������ ������ ������Ʈ
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // �����̴��� Ȱ��ȭ/��Ȱ��ȭ�ϴ� ��ư Ŭ�� �̺�Ʈ ����
        toggleButton.onClick.AddListener(ToggleSlider);
    }

    // ������ �����ϴ� �Լ�
    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // �����̴� Ȱ��ȭ/��Ȱ��ȭ �Լ�
    void ToggleSlider()
    {
        volumeSlider.interactable = !volumeSlider.interactable;  // ���� ������ �ݴ밪���� ����
    }
}


