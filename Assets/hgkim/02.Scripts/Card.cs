using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField, Tooltip("ī�� �ո�")] GameObject frontGO;
    [SerializeField, Tooltip("ī�� �޸�")] GameObject backGO;

    [SerializeField, Tooltip("ī�� �ո� ������Ʈ�� ��������Ʈ ������")] SpriteRenderer frontImg;

    public int cardIdx = 0;     // ī�� ��ȣ

    /// <summary>
    /// ���ӸŴ����κ��� ��ȣ�� �ް�
    /// ī�� �ո��� �̹����� ��ȣ�� ���� �ٲٴ� �Լ�
    /// </summary>
    /// <param name="index"></param>
    public void CardImageSet(int index)
    {
        cardIdx = index;    // ���ӸŴ������� ���� ��ȣ�� cardIdx�� ������
        frontImg.sprite = Resources.Load<Sprite>($"TMI_0{cardIdx}");
    }
}
