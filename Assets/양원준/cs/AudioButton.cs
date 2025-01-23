using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioButton : MonoBehaviour
{

    public Slider volumeSlider;
    public Button toggleButton;  // 슬라이더 활성화/비활성화 버튼

    void Start()
    {
        // 슬라이더의 초기 값을 현재 볼륨에 맞게 설정
        volumeSlider.value = AudioListener.volume;

        // 슬라이더 값이 변경될 때마다 볼륨을 업데이트
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // 슬라이더를 활성화/비활성화하는 버튼 클릭 이벤트 연결
        toggleButton.onClick.AddListener(ToggleSlider);
    }

    // 볼륨을 설정하는 함수
    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // 슬라이더 활성화/비활성화 함수
    void ToggleSlider()
    {
        volumeSlider.interactable = !volumeSlider.interactable;  // 현재 상태의 반대값으로 설정
    }
}


