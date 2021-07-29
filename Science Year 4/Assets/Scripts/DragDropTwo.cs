using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DragDropTwo : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public Transform startPos;

    [SerializeField] private Sprite[] sprite;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        rectTransform.sizeDelta = new Vector2(100, 100);

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        rectTransform.position = eventData.pointerPressRaycast.worldPosition; // this is it!
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        rectTransform.sizeDelta = new Vector2(700, 160);
        transform.position = startPos.position;

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
