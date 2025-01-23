using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndPanel : MonoBehaviour
{
    public List<TMI_Details> tMI_Details;
    public Text ownerName;
    public Image zepImage;
    public Image detailImage_01;
    public Text detailTxt_01;
    public Image detailImage_02;
    public Text detailTxt_02;
    public Button prevBtn;
    public Button nextBtn;
    public int pageCount = 4;
    public int currentPage = 0;
    void Start()
    {
        
    }
    void Update()
    {
        ownerName.text = tMI_Details[currentPage * 2].Owner;

        zepImage.sprite = tMI_Details[currentPage * 2].ZepImage;

        detailImage_01.sprite = tMI_Details[currentPage * 2].Image;
        detailTxt_01.text = tMI_Details[currentPage * 2].Detail;

        detailImage_02.sprite = tMI_Details[currentPage * 2 + 1].Image;
        detailTxt_02.text = tMI_Details[currentPage * 2 + 1].Detail;
    }
    public void OnMovePrevPage()
    {
        currentPage--;
        if(currentPage <= 0)
        {
            currentPage = 0;
        }
    }
    public void OnMoveNextPage()
    {
        currentPage++;
        if(currentPage >= pageCount)
        {
            currentPage = pageCount;
        }
    }
}
