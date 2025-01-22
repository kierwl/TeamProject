using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //싱글톤
    public Text timeTxt;                    //시간 텍스트
    public GameObject endTxt;               //끝날 때 나오는 텍스트
    public GameObject detailBox;            //카드 설명 패널
    public GameObject emptyPanel;           //카드 터치 방지용
    float time = 0f;                        //시작 시간(현재 시간)
    public int cardCount = 0;               //카드 개수
    public Card firstCard;                  //첫번째 카드
    public Card secondCard;                 //두번째 카드
    AudioSource audioSource;                //BGM
    public AudioClip clip;
    public Image detailBoxImg;              //맞춘 카드의 이미지
    public bool isRunning = true;           //시간이 작동하는지
    
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

        //60초를 넘거나 카드개수가 0이면서 작동중일 때 게임 그만
        if((time >= 60.0f) || (cardCount == 0 && isRunning))    
        {
            GameFinish();       
        }
    }
    void GameFinish()
    {
        Time.timeScale = 0.0f;              //게임 잠시 멈추고
        endTxt.SetActive(true);             //끝났다는 글자 등장 -> 이부분을 TMI 나오는 방향으로
    }
    public void Matched()                   //열어 본 카드 두개 비교
    {
        if(firstCard.cardIdx == secondCard.cardIdx)     //일치할 경우
        {
            audioSource.PlayOneShot(clip);

            firstCard.CallDestroyCard();
            secondCard.CallDestroyCard();

            ShowDetails(firstCard);                     //디테일 보여줌

            cardCount -= 2;                             //카드 개수 업데이트
        }
        else                                            //불일치할 경우
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
