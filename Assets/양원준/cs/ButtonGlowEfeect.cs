using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // UI �̺�Ʈ �ý��� ���

public class ButtonGlowEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Button targetButton;  // ��ư
    private Material buttonMaterial;  // ��ư�� ����� Material
    private bool isPressed = false;  // ��ư�� ���ȴ��� Ȯ��

    public Color defaultColor = Color.white;  // �⺻ ���� ���� (��: ���)
    public Color glowColor = Color.green;  // Glow ȿ���� Ȱ��ȭ�� ������ ����

    void Start()
    {
        // ��ư�� Material ��������
        buttonMaterial = targetButton.GetComponent<Image>().material;

        // �⺻ ���� ���� (UI ��ư���� ���Ǵ� �⺻ ������ ���)
        buttonMaterial.SetColor("_Color", defaultColor);

    }

    // ���콺�� ��ư ���� �÷��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonMaterial.SetFloat("_GlowIntensity", 2.0f);  // Hover ���¿��� �߱�
    }

    // ���콺�� ��ư�� ��� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isPressed)
        {
            buttonMaterial.SetFloat("_GlowIntensity", 0.8f);  // Hover ���¿��� ����� �߱� ����
        }
    }

    // ��ư�� ������ ��
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        buttonMaterial.SetFloat("_GlowIntensity", 0.0f);  // ������ �� ���� ��
    }

    // ��ư�� �����ٰ� ������ ��
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        buttonMaterial.SetFloat("_GlowIntensity", 1.0f);  // �����ٰ� ���� �ٽ� �߱�
    }
}



