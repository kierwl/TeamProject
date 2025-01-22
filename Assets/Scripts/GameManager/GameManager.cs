using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //싱글톤
    public Text timeTxt;                    //시간 텍스트
    public GameObject endTxt;               //끝날 때 나오는 텍스트
    float time = 0f;                        //시작 시간(현재 시간)

    public Card firstCard;                  //첫번째 카드
    public Card secondCard;                 //두번째 카드
    public int cardcount = 0;               //카드 개수
    


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

        if(time >= 60.0f)                   //60초를 넘으면 게암을 끝내라
        {
            GameFinish();       
        }
    }


    void GameFinish()
    {
        Time.timeScale = 0.0f;              //게임 잠시 멈추고
        endTxt.SetActive(true);             //끝났다는 글자 등장
    }
    public void Matched()                   //열어 본 카드 두개 비교
    {

    }
}
