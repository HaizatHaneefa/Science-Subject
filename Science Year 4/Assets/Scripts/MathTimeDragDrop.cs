using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MathTimeDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public Transform[] startPos;

    TimeQuizManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeQuizManager>();

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        rectTransform.sizeDelta = new Vector2(80, 80);

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        rectTransform.position = eventData.pointerPressRaycast.worldPosition; // this is it!
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.sizeDelta = new Vector2(130, 130);

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

        if (transform.CompareTag("Animal 1"))
        {
            transform.position = startPos[0].position;
        }
        else if (transform.CompareTag("Animal 2"))
        {
            transform.position = startPos[1].position;
        }
        else if (transform.CompareTag("Animal 3"))
        {
            transform.position = startPos[2].position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
