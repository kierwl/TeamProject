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
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 ,7, 7, 8, 8, 9, 9 }; // 0부터 9 까지 총 10개의 배열이 두개씩 입력됨
		arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray(); // 0부터 7까지 8개의 배열을 랜덤한 위치에 배정
        for (int i = 0; i < 20; i++) // 위치의 인덱스값을 섞는 for문 총 16개의 위치를 랜덤하게 지정하기 위함
        {
            GameObject go = Instantiate(card, this.transform); // 게임오브젝트의 위치값을 받아옴

            float x = (i % 5) * 1.1f - 2.2f; // x축 카드의 간격 계산
            float y = (i / 5) * 1.1f - 3.2f; // y축 카드의 간격 계산
            
            go.transform.position = new Vector2(x, y); // 위치값 평면기준으로 벡터2d 생성
            go.GetComponent<Card>().CardImageSet(arr[i]);// 카드 컴포넌트를 불러오고 세팅함수에서 배열[인덱스번호]로 변경
        }
        GameManager.Instance.cardCount = arr.Length; // 게임매니저에서 카드의 수를 배열의 길이만큼 변경
    }
}
