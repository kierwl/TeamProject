﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField, Tooltip("카드 앞면")] GameObject frontGO;
    [SerializeField, Tooltip("카드 뒷면")] GameObject backGO;

    [SerializeField, Tooltip("카드 앞면 오브젝트의 스프라이트 렌더러")] SpriteRenderer frontImg;

    public int cardIdx = 0;     // 카드 번호

    /// <summary>
    /// 게임매니저로부터 번호를 받고
    /// 카드 앞면의 이미지를 번호에 맞춰 바꾸는 함수
    /// </summary>
    /// <param name="index"></param>
    public void CardImageSet(int index)
    {
        cardIdx = index;    // 게임매니저에서 받은 번호를 cardIdx의 값으로
        frontImg.sprite = Resources.Load<Sprite>($"TMI_0{cardIdx}");
    }

    /// <summary>
    /// 카드를 앞면으로 바꾸는 함수
    /// </summary>
    public void ReverseCard()
    {
        Debug.Log("Reverse");
        // 카드의 활성 상태를 현재 상태의 반대가 되도록 전환
        bool isActive = !frontGO.activeSelf;
        frontGO.SetActive(isActive);
        isActive = !backGO.activeSelf;
        backGO.SetActive(isActive);

        GameManager gm = GameManager.Instance;

        // 이 카드가 뒤집히기 전에 뒤집힌 카드가 없다면
        if(gm.firstCard == null)
        {
            gm.firstCard = this;
        }
        else
        {// 카드 한 장이 이미 뒤집힌 상태라면
            gm.secondCard = this;
            // 게임매니저에서 매치 확인 함수를 호출
        }
    }

    /// <summary>
    /// 같은 그림의 카드가 매치됐을 때 호출되는 함수
    /// </summary>
    public void CallDestroyCard()
    {
        // 0.5초 후에 DestroyCard 함수 호출
        Invoke("DestroyCard", 0.5f);
    }

    /// <summary>
    /// 카드 게임 오브젝트 파괴
    /// </summary>
    private void DestroyCard()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 뒤집힌 2장의 카드가 서로 다른 그림일 때 호출되는 함수
    /// </summary>
    public void CallCloseCard()
    {
        // 0.5초 후에 ReverseCard 함수 호출
        Invoke("ReverseCard", 0.5f);
    }
}
