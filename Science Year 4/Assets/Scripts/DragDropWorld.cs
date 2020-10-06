using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragDropWorld : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public Transform[] startPos;

    WorldMapManager manager;


    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WorldMapManager>();

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        rectTransform.sizeDelta = new Vector2(40, 40);

        //    transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (gameObject.CompareTag("Day"))
        {
            transform.position = startPos[0].position;
        }
        else if (gameObject.CompareTag("Night"))
        {
            transform.position = startPos[1].position;
        }

        rectTransform.sizeDelta = new Vector2(60, 60);

        //transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
