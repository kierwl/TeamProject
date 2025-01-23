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
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        // ����� ������ PlayerPrefs�� ����
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    // �����̴� Ȱ��ȭ/��Ȱ��ȭ �Լ�
    public void ToggleSlider()
    {
        // ���� ������Ʈ Ȱ��ȭ ���� Ȯ��
        bool isActive = volumeSlider.gameObject.activeSelf;

        // �����̴��� Ȱ��ȭ/��Ȱ��ȭ ���
        volumeSlider.gameObject.SetActive(!isActive);

        // �α׷� ���� Ȯ��
        Debug.Log("Slider active: " + volumeSlider.gameObject.activeSelf);
    }
}


