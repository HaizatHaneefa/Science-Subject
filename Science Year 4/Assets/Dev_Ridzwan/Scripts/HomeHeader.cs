using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class HomeHeader : MonoBehaviour
{
    public RectTransform panel;
    public Button backButton;
    [SerializeField] RectTransform levelContainer;
    [SerializeField] RectTransform titleBar;
    public TextMeshProUGUI titleName;
    public TextMeshProUGUI titleSubject;

    Vector2 titleBarShowPos;
    Vector2 titleBarHidePos;
    Vector2 backButtonShowPos;
    Vector2 backButtonHidePos;

    public Vector2 titlePosLeft => Vector2.left * titleName.rectTransform.sizeDelta.x;
    public Vector2 titlePosRight => Vector2.right * titleName.rectTransform.sizeDelta.x;

    void Awake()
    {
        titleBarShowPos = titleBar.anchoredPosition;
        titleBarHidePos =
            titleBarShowPos
            + (Vector2.left * titleBar.sizeDelta.x)
            + (Vector2.left * titleBar.anchoredPosition.x);

        RectTransform backButtonRect = backButton.targetGraphic.rectTransform;
        backButtonShowPos = backButtonRect.anchoredPosition;
        backButtonHidePos = backButtonShowPos + (Vector2.left * (backButtonRect.sizeDelta.x + backButtonShowPos.x));
    }

    IEnumerator Start()
    {
        yield return null;
        // if (GameSystemSetting.isActivity) {
            titleName.rectTransform.anchoredPosition = titlePosRight;
            titleSubject.rectTransform.anchoredPosition = Vector2.zero;
        // }
    }

    public void MenuNavigation(Action callback)
    {
        panel.DOAnchorPosY(0f, 0.5f, false).SetEase(Ease.OutQuad).OnComplete(() => {
            titleBar.DOAnchorPos(titleBarShowPos, 0.5f, false).SetEase(Ease.OutQuad);
            backButton.targetGraphic.rectTransform.DOAnchorPos(backButtonShowPos, 0.5f, false).SetEase(Ease.OutQuad);
            backButton.onClick.RemoveAllListeners();
            callback?.Invoke();
        });
    }

    public void Hide()
    {
        panel.anchoredPosition = Vector2.up * panel.sizeDelta.y;
        backButton.targetGraphic.rectTransform.anchoredPosition = backButtonHidePos;
        titleBar.anchoredPosition = titleBarHidePos;
    }

    public void AnimatedHide()
    {
        titleBar.DOAnchorPos(titleBarHidePos, 0.25f, false).SetEase(Ease.OutQuad);
        backButton.targetGraphic.rectTransform
        .DOAnchorPos(backButtonHidePos, 0.25f, false)
        .SetEase(Ease.OutQuad)
        .OnComplete(() => {
            panel.DOAnchorPosY(panel.sizeDelta.y, 0.5f, false).SetEase(Ease.OutQuad);
        });
    }

    public void ShiftTitle(bool isSubjectShown)
    {
        if (isSubjectShown) {
            titleName.rectTransform.DOAnchorPos(Vector2.zero, 0.5f, false).SetEase(Ease.OutQuad);
            titleSubject.rectTransform.DOAnchorPos(titlePosLeft, 0.5f, false).SetEase(Ease.OutQuad);
        } else {
            titleName.rectTransform.DOAnchorPos(titlePosRight, 0.5f, false).SetEase(Ease.OutQuad);
            titleSubject.rectTransform.DOAnchorPos(Vector2.zero, 0.5f, false).SetEase(Ease.OutQuad);
        }
    }

    public void HideLevel(bool animate)
    {
        Vector2 targetPos = Vector2.right * levelContainer.sizeDelta.x;
        if (animate) {
            levelContainer.DOAnchorPos(targetPos, 0.5f).SetEase(Ease.OutQuad);
        } else {
            levelContainer.anchoredPosition = targetPos;
        }
    }

    public void ShowLevel(bool animate)
    {
        if (animate) {
            levelContainer.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutQuad);
        } else {
            levelContainer.anchoredPosition = Vector2.zero;
        }

    }

    public void NameToLeft() => titleName.rectTransform.anchoredPosition = titlePosLeft;
    public void NameToRight() => titleName.rectTransform.anchoredPosition = titlePosRight;
    public void NameToCenter() => titleName.rectTransform.anchoredPosition = Vector2.zero;

    public void SubjectToLeft() => titleSubject.rectTransform.anchoredPosition = titlePosLeft;
    public void SubjectToRight() => titleSubject.rectTransform.anchoredPosition = titlePosRight;
    public void SubjectToCenter() => titleSubject.rectTransform.anchoredPosition = Vector2.zero;
}
