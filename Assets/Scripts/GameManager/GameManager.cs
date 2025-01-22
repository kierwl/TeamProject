using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //싱글톤
    public Text timeTxt;                    //시간 텍스트
    public GameObject endTxt;               //끝날 때 나오는 텍스트 (바뀜)
    public GameObject detailBox;            //카드 설명 패널
    public GameObject emptyPanel;           //카드 터치 방지용
    float time = 0f;                        //시작 시간(현재 시간)
    public int cardCount = 0;               //카드 개수
    public Card firstCard;                  //첫번째 카드
    public Card secondCard;                 //두번째 카드
    AudioSource audioSource;                //BGM
    public AudioClip clip;                  //BGM 클립
    public Image detailBoxImg;              //맞춘 카드의 이미지
    public bool isRunning = true;           //시간이 작동하는지
    public Text ownerTxt;                   //맞춘 카드의 주인
    public Text detailTxt;                  //맞춘 카드의 TMI
    public GameObject endPanel;             //성공시의 패널
    public GameObject failPanel;            //실패시의 패널
    public List<TMI_Details> tMI_Details;   //TMI 정보들



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        time += Time.deltaTime;             //시간 경과중
        timeTxt.text = time.ToString("N2");

        if(time >= 60.0f)
        {
            GameFail();
        }
        if (cardCount == 0 && isRunning)
        {
            GameFinish();
        }
    }
    void GameFinish()
    {
        Time.timeScale = 0.0f;              //게임 잠시 멈추고
        endPanel.SetActive(true);           //끝났다는 글자 등장 -> 이부분을 TMI 나오는 방향으로
    }
    void GameFail()
    {
        Time.timeScale = 0.0f;              //게임 잠시 멈추고
        failPanel.SetActive(true);          //실패 패널 등장
    }
    public void Matched()                   //열어 본 카드 두개 비교
    {
        if(firstCard.cardIdx == secondCard.cardIdx)     //일치할 경우
        {
            //audioSource.PlayOneShot(clip);

            firstCard.CallDestroyCard();
            secondCard.CallDestroyCard();

            ShowDetails(firstCard);                     //디테일 보여줌

            cardCount -= 2;                             //카드 개수 업데이트
        }
        else                                            //불일치할 경우 다시 닫기
        {
            firstCard.CallCloseCard();
            secondCard.CallCloseCard();
        }
                                                        //매치카드 초기화
        firstCard = null;
        secondCard = null;
    }
    void ShowDetails(Card card)
    {
        detailBox.SetActive(true);
        emptyPanel.SetActive(true);

        detailBoxImg.sprite = card.frontGO.GetComponent<SpriteRenderer>().sprite;

        int index = card.cardIdx;
        ownerTxt.text = tMI_Details[index].Owner;
        detailTxt.text = tMI_Details[index].Detail;
        isRunning = false;

        StartCoroutine(ResumeGame());
    }
    IEnumerator ResumeGame()
    {
        yield return new WaitForSeconds(5.0f);

        isRunning = true;

        detailBox.SetActive(false);
        emptyPanel.SetActive(false);

        yield break;
    }
}
