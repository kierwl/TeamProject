using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // 볼륨 슬라이더 참조
    public Text volumeText;      // 볼륨 텍스트 참조

    private void Start()
    {
        // 초기 볼륨 값을 슬라이더에 설정
        volumeSlider.value = AudioListener.volume;

        // 슬라이더 값이 변경될 때마다 호출될 이벤트 추가
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // 시작 시 텍스트에 현재 볼륨 표시
        UpdateVolumeText(volumeSlider.value);
    }

    // 볼륨 값 변경 시 호출되는 함수
    private void OnVolumeChanged(float value)
    {
        // 오디오 리스너의 볼륨을 변경
        AudioListener.volume = value;

        // 텍스트 업데이트
        UpdateVolumeText(value);
    }

    // 볼륨 텍스트 업데이트
    private void UpdateVolumeText(float value)
    {
        volumeText.text = "Volume: " + Mathf.RoundToInt(value * 100) + "%";
    }
}
