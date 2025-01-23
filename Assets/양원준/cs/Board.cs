using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Transform cards; // ī���� ��ġ 
    public GameObject card; // ������ ī�� ������Ʈ
    public int cardcount = 0; // ī���� �� ���� �ʱⰪ 0

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 }; // 0���� 9���� �� 20���� ��
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray(); // �迭�� ������ ��ġ�� ����

        for (int i = 0; i < 20; i++) // �� 20���� ī�带 ����
        {
            GameObject go = Instantiate(card, this.transform); // ī�� ������ ����

            float x = (i % 4) * 1.2f - 1.7f; // x�� ī�� ���� ���
            float y = (i / 4) * 1.1f - 3.2f; // y�� ī�� ���� ��� (4�� ����)

            go.transform.position = new Vector2(x, y); // ��ġ�� ��� �������� ����
            go.GetComponent<Card>().CardImageSet(arr[i]); // ī�� �̹��� ����
        }

        GameManager.Instance.cardCount = arr.Length; // ī�� ���� GameManager�� ����
    }
}
