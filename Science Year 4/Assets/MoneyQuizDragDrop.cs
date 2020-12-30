using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyQuizDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    [SerializeField] private Transform startPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        rectTransform.sizeDelta = new Vector2(75-10, 50-10);

        rectTransform.position = eventData.pointerPressRaycast.worldPosition; // this is it!
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        rectTransform.sizeDelta = new Vector2(150, 100);
        transform.position = startPos.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
