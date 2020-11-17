using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class HomeAutoPadding : MonoBehaviour
{
    [SerializeField] RectTransform viewport;
    [SerializeField] float spacing = 60;
    [SerializeField] float duration = 0.5f;
    [SerializeField] RectTransform scrollView;
    HorizontalLayoutGroup layoutGroup;
    RectTransform rectTransform;
    RectTransform card;
    public bool isAnimating {private set; get;}
    bool isHidden = true;

    void Awake() {
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        card = layoutGroup.transform.GetChild(0).GetComponent<RectTransform>();
    }

    IEnumerator Start() {
        scrollView.anchoredPosition = new Vector2(0f, -scrollView.rect.height);
        layoutGroup.spacing = -card.rect.width;
        yield return null;
        SetPadding();
    }

    void SetPadding() {
        int padding = Mathf.RoundToInt((viewport.rect.width / 2) - (card.rect.width / 2));
        layoutGroup.padding.left = padding;
        layoutGroup.padding.right = padding;
    }

    [ContextMenu("Show")]
    public bool Show(Action callback = null) {
        if (isAnimating) return false;

        StartCoroutine(ShowRoutine(callback));
        return true;
    }

    IEnumerator ShowRoutine(Action callback) {
        if (!isHidden) {
            callback?.Invoke();
            yield break;
        }
        isHidden = false;
        isAnimating = true;
        yield return scrollView.DOAnchorPosY(0f, duration).SetEase(Ease.OutBack).WaitForCompletion();
        yield return layoutGroup.DOSpace(spacing, duration).SetEase(Ease.OutBack).WaitForCompletion();
        yield return rectTransform.DOAnchorPosX(rectTransform.sizeDelta.x / 2, 1f).SetEase(Ease.OutExpo).WaitForCompletion();
        callback?.Invoke();
        isAnimating = false;
    }

    [ContextMenu("Hide")]
    public bool Hide(Action callback = null) {
        if (isAnimating) return false;
        
        StartCoroutine(HideRoutine(callback));
        return true;
    }

    IEnumerator HideRoutine(Action callback)
    {
        if (isHidden) {
            callback?.Invoke();
            yield break;
        }
        isHidden = true;
        isAnimating = true;
        yield return rectTransform.DOAnchorPosX(0f, duration).SetEase(Ease.OutBack).WaitForCompletion();
        yield return layoutGroup.DOSpace(-card.rect.width, duration).SetEase(Ease.InBack).WaitForCompletion();
        yield return scrollView.DOAnchorPosY(-scrollView.rect.height, duration).SetEase(Ease.InBack).WaitForCompletion();
        callback?.Invoke();
        isAnimating = false;
    }
}
