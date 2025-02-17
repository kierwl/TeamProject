using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // 싱글톤

    AudioSource audioSource;
    public AudioClip bgm; //bgm
    public AudioClip flip;
    public AudioClip CLOSESound;
    public AudioClip MatchedSound;
    public AudioClip Fail;
    public AudioClip Victory;
    public AudioClip menusound;


    private bool hasIncreasedPitch = false;
    private bool hasFurtherIncreasedPitch = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        
    }
        
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.Play(); // BGM 재생

        audioSource.volume = 0.6f;
        
    }

    private void Update()
    {
        // 시간이 50초를 넘으면 피치 증가
        if (GameManager.Instance.time > 40.0f && !hasIncreasedPitch)
        {
            audioSource.pitch = 1.2f;
            hasIncreasedPitch = true; // 한 번만 적용되도록 플래그 설정
        }

        // 시간이 55초에서 60초 사이일 경우 피치 더욱 증가
        if (GameManager.Instance.time > 50.0f && GameManager.Instance.time <= 60.0f && !hasFurtherIncreasedPitch)
        {
            audioSource.pitch = 1.4f;
            hasFurtherIncreasedPitch = true; // 한 번만 적용되도록 플래그 설정
        }

    }
    public void SetMute(bool isMuted)
    {
        if (audioSource != null)
        {
            audioSource.mute = isMuted; // AudioSource의 mute 속성을 설정
        }
    }

    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip); // 1회재생
        }
    }
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // BGM 정지
        }
    }



    
}
