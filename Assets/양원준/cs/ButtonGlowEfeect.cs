using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // UI 이벤트 시스템 사용

public class ButtonGlowEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Button targetButton;  // 버튼
    private Material buttonMaterial;  // 버튼에 적용된 Material
    private bool isPressed = false;  // 버튼이 눌렸는지 확인

    public Color defaultColor = Color.white;  // 기본 색상 설정 (예: 흰색)
    public Color glowColor = Color.green;  // Glow 효과가 활성화된 상태의 색상

    void Start()
    {
        // 버튼에 Material 가져오기
        buttonMaterial = targetButton.GetComponent<Image>().material;

        // 기본 색상 설정 (UI 버튼에서 사용되는 기본 색상은 흰색)
        buttonMaterial.SetColor("_Color", defaultColor);

    }

    // 마우스가 버튼 위에 올렸을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonMaterial.SetFloat("_GlowIntensity", 2.0f);  // Hover 상태에서 발광
    }

    // 마우스가 버튼을 벗어날 때
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isPressed)
        {
            buttonMaterial.SetFloat("_GlowIntensity", 0.8f);  // Hover 상태에서 벗어나면 발광 끄기
        }
    }

    // 버튼을 눌렀을 때
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        buttonMaterial.SetFloat("_GlowIntensity", 0.0f);  // 눌렸을 때 색을 끔
    }

    // 버튼을 눌렀다가 떼었을 때
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        buttonMaterial.SetFloat("_GlowIntensity", 1.0f);  // 눌렀다가 떼면 다시 발광
    }
}



