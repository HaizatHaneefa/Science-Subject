using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class TweenAnchorPos : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] Vector2 showPos;
    [SerializeField] Vector2 hidePos;
    [SerializeField] Ease easing = Ease.OutBack;
    [SerializeField] float duration = 0.3f;
    bool isShowing = false;

    void Awake()
    {
        SetRectTransform();
    }

    void Start() {
        Hide(true);
    }

    public void Show(bool instant = false)
    {
        isShowing = true;
        if (instant) {
            rectTransform.anchoredPosition = showPos;
            return;
        }
        rectTransform.DOAnchorPos(showPos, duration).SetEase(easing);
    }

    public void Hide(bool instant = false)
    {
        isShowing = false;
        if (instant) {
            rectTransform.anchoredPosition = hidePos;
            return;
        }
        rectTransform.DOAnchorPos(hidePos, duration).SetEase(easing);
    }

    public void DelayedShow(float delay) {
        rectTransform.DOAnchorPos(showPos, duration).SetEase(easing).SetDelay(delay).OnStart(() => isShowing = true);
    }

    public void DelayedHide(float delay) {
        rectTransform.DOAnchorPos(hidePos, duration).SetEase(easing).SetDelay(delay).OnStart(() => isShowing = false);
    }

    public void Toggle()
    {
        if (isShowing) {
            Hide();
        } else {
            Show();
        }
    }

    [ContextMenu("Set Show Position")]
    void SetShowPos()
    {
        SetRectTransform();
        showPos = rectTransform.anchoredPosition;
    }

    [ContextMenu("Set Hide Position")]
    void SetHidePos()
    {
        SetRectTransform();
        hidePos = rectTransform.anchoredPosition;
    }
    
    [Button("Show")]
    void InstantShow() => Show(true);

    [Button("Hide")]
    void InstantHide() => Hide(true);

    void SetRectTransform()
    {
        if (rectTransform) {
            return;
        }
        rectTransform = GetComponent<RectTransform>();
    }
}
