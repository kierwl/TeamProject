using System.Collections;
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
}
