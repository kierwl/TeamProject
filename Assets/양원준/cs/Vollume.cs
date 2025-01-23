using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // ���� �����̴� ����
    public Text volumeText;      // ���� �ؽ�Ʈ ����

    private void Start()
    {
        // �ʱ� ���� ���� �����̴��� ����
        volumeSlider.value = AudioListener.volume;

        // �����̴� ���� ����� ������ ȣ��� �̺�Ʈ �߰�
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // ���� �� �ؽ�Ʈ�� ���� ���� ǥ��
        UpdateVolumeText(volumeSlider.value);
    }

    // ���� �� ���� �� ȣ��Ǵ� �Լ�
    private void OnVolumeChanged(float value)
    {
        // ����� �������� ������ ����
        AudioListener.volume = value;

        // �ؽ�Ʈ ������Ʈ
        UpdateVolumeText(value);
    }

    // ���� �ؽ�Ʈ ������Ʈ
    private void UpdateVolumeText(float value)
    {
        volumeText.text = "Volume: " + Mathf.RoundToInt(value * 100) + "%";
    }
}
