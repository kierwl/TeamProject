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
    public float time = 0f;                 //시작 시간(현재 시간)
    public int cardCount = 0;               //카드 개수
    public Card firstCard;                  //첫번째 카드
    public Card secondCard;                 //두번째 카드
    public AudioSource audioSource;                //BGM
    public AudioClip clip;                  //BGM 클립
    public Image detailBoxImg;              //맞춘 카드의 이미지
    public bool isRunning = true;           //시간이 작동하는지
    public Text ownerTxt;                   //맞춘 카드의 주인
    public Text detailTxt;                  //맞춘 카드의 TMI
    public GameObject endPanel;             //성공시의 패널
    public GameObject failPanel;            //실패시의 패널
    public List<TMI_Details> tMI_Details;   //TMI 정보들
    public GameObject particlePrefab;       //파티클 추가


    public int count = 0;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
           
        }
        
    }
    void Start()
    {
        Reset();
        Time.timeScale = 1.0f;

    }
    void Update()
    {
        if(isRunning)
        {
            time += Time.deltaTime;
        }
        timeTxt.text = time.ToString("N2");

        if(time >= 60.0f)
        {
            GameFail();
        }
        if (cardCount == 0 && isRunning)
        {
            GameFinish();
        }
        if(count == 2)
        {
            emptyPanel.SetActive(true);
        }
    }
    void GameFinish()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);
        AudioManager.Instance.SetMute(true);

    }

    void GameFail()
    {
        Time.timeScale = 0.0f;
        failPanel.SetActive(true);
        AudioManager.Instance.SetMute(true);

    }

    
   
    void Reset()
    {
        // 게임 상태 초기화
        time = 0f;
        cardCount = 0;
        firstCard = null;
        secondCard = null;
        isRunning = true;
        
        // UI 초기화
        timeTxt.text = "0.00";
        endPanel.SetActive(false);
        failPanel.SetActive(false);
        detailBox.SetActive(false);
        emptyPanel.SetActive(false);
        AudioManager.Instance.SetMute(false);
    }

    public void Matched()                   //열어 본 카드 두개 비교
    {
        if(firstCard.cardIdx == secondCard.cardIdx)     //일치할 경우
        {
            //audioSource.PlayOneShot(clip);

            firstCard.CallDestroyCard();
            secondCard.CallDestroyCard();
            SpawnParticleEffect(secondCard.transform.position);
            ShowDetails(firstCard);                     //디테일 보여줌

            AudioManager.Instance?.PlaySound(AudioManager.Instance.MatchedSound);

            cardCount -= 2;                             //카드 개수 업데이트
        }
        else                                            //불일치할 경우 다시 닫기
        {
            firstCard.CallCloseCard();
            secondCard.CallCloseCard();
            AudioManager.Instance?.PlaySound(AudioManager.Instance.CLOSESound);
            emptyPanel.SetActive(false);
        }
                                                        //매치카드 초기화
        firstCard = null;
        secondCard = null;
    }
    private void SpawnParticleEffect(Vector3 position) // 파티클 생성
    {
        // 파티클을 카드 위치에서 생성
        Instantiate(particlePrefab, position, Quaternion.identity);
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
