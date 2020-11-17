using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class TabMenu : MonoBehaviour
{
    [SerializeField] RectTransform panel;
    [Header ("Open Settings")]
    [SerializeField] Vector2 openPosition;
    [SerializeField] float openDuration = 0.5f;
    [SerializeField] Ease openEasing = Ease.OutCubic;
    [Button] void SetOpenPosition() => openPosition = panel.anchoredPosition;

    [Header ("Closed Settings")]
    [SerializeField] Vector2 closedPosition;
    [SerializeField] float closedDuration = 0.5f;
    [SerializeField] Ease closedEasing = Ease.OutCubic;
    [Button] void SetClosedPosition() => closedPosition = panel.anchoredPosition;

    public bool isOpen {private set; get;}
    Sequence sequence = null;

    void Start() {
        SetState(false);
    }

    public void SetState(bool open) => SetState(open, false);
    public void SetState(bool open, bool instant) {
        if (sequence != null) return;

        sequence = DOTween.Sequence();
        if (open) {
            sequence.Append(panel.DOAnchorPos(openPosition, openDuration).SetEase(openEasing));
        } else {
            sequence.Append(panel.DOAnchorPos(closedPosition, closedDuration).SetEase(closedEasing));
        }
        sequence
            .OnComplete(() => isOpen = open)
            .OnKill(() => sequence = null);

        if (instant) {
            sequence.Complete();
        }
    }

    public void Toggle() {
        SetState(!isOpen);
    }
}
