using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // 싱글톤

    AudioSource audioSource;
    public AudioClip bgm; // bgm


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bgm; 
        audioSource.Play(); // bgm 실행
    }

    //private void Update()
    //// 50, 55초 될 때 사운드 피치 올려서 긴박감 연출 (GamaeManager.cs에서 time 변수 public으로 바꾸는 게 필요함)
    //{
    //    if (GameManager.Instance.time > 50.0f)
    //    {
    //        audioSource.pitch = 1.2f;
    //    }
    //    if (GameManager.Instance.time > 55.0f && GameManager.Instance.time <= 60.0f)
    //    {
    //        audioSource.pitch = 1.4f;
    //    }
    //}
}
