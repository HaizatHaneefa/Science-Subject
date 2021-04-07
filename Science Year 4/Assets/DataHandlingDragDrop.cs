using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataHandlingDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform thisTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    [SerializeField] private DataHandlingGameManager manager;

    private void Awake()
    {
        thisTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DataHandlingGameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        thisTransform.position = eventData.pointerPressRaycast.worldPosition; // this is it!
    }

    public void OnDrag(PointerEventData eventData)
    {
        thisTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        eventData.pointerDrag.transform.position = manager.spawn.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.PressSFX();
    }
}
