using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Transform cards; // 카드의 위치 
    public GameObject card; // 프리팹 카드 오브젝트
    public int cardcount = 0; // 카드의 총 개수 초기값 0

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 }; // 0부터 9까지 총 20개의 값
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray(); // 배열을 랜덤한 위치에 배정

        for (int i = 0; i < 20; i++) // 총 20개의 카드를 생성
        {
            GameObject go = Instantiate(card, this.transform); // 카드 프리팹 생성

            float x = (i % 4) * 1.2f - 1.7f; // x축 카드 간격 계산
            float y = (i / 4) * 1.1f - 3.2f; // y축 카드 간격 계산 (4열 기준)

            go.transform.position = new Vector2(x, y); // 위치값 평면 기준으로 설정
            go.GetComponent<Card>().CardImageSet(arr[i]); // 카드 이미지 세팅
        }

        GameManager.Instance.cardCount = arr.Length; // 카드 수를 GameManager에 전달
    }
}
