using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // �̱���

    AudioSource audioSource;
    public AudioClip bgm; // bgm


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
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
        audioSource.Play(); // bgm ����
    }

    //private void Update()
    //// 50, 55�� �� �� ���� ��ġ �÷��� ��ڰ� ���� (GamaeManager.cs���� time ���� public���� �ٲٴ� �� �ʿ���)
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
