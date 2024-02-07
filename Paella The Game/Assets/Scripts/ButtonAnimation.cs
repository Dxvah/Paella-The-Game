using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Vector3 originalScale;

    private void Start()
    {
       originalScale = transform.localScale;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, originalScale * 1.1f, 0.1f).setEase(LeanTweenType.easeOutQuad);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, originalScale, 0.1f).setEase(LeanTweenType.easeOutQuad);
        
    }
}

