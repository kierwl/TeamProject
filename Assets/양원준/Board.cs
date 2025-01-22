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
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 ,7, 7, 8, 8, 9, 9 }; // 0���� 9 ���� �� 10���� �迭�� �ΰ��� �Էµ�
		arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray(); // 0���� 7���� 8���� �迭�� ������ ��ġ�� ����
        for (int i = 0; i < 20; i++) // ��ġ�� �ε������� ���� for�� �� 16���� ��ġ�� �����ϰ� �����ϱ� ����
        {
            GameObject go = Instantiate(card, this.transform); // ���ӿ�����Ʈ�� ��ġ���� �޾ƿ�

            float x = (i % 5) * 1.1f - 2.2f; // x�� ī���� ���� ���
            float y = (i / 5) * 1.1f - 3.2f; // y�� ī���� ���� ���
            
            go.transform.position = new Vector2(x, y); // ��ġ�� ���������� ����2d ����
            go.GetComponent<Card>().CardImageSet(arr[i]);// ī�� ������Ʈ�� �ҷ����� �����Լ����� �迭[�ε�����ȣ]�� ����
        }
        GameManager.Instance.cardCount = arr.Length; // ���ӸŴ������� ī���� ���� �迭�� ���̸�ŭ ����
    }
}
