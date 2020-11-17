using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HeaderTitleResize : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] TextMeshProUGUI nameLabel;
    [SerializeField] TextMeshProUGUI subjectLabel;
    [SerializeField] float padding;
    [SerializeField] float duration;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {

    }

    public void Resize(TextMeshProUGUI label)
    {
        Vector2 newSizeDelta = new Vector2(label.preferredWidth + padding + padding, rectTransform.sizeDelta.y);
        rectTransform.DOSizeDelta(newSizeDelta, duration).SetEase(Ease.OutQuad);
    }

    public void TitleShift(bool isSubjectShown)
    {
        StartCoroutine(ShiftRoutine(isSubjectShown));
        if (isSubjectShown) {
            nameLabel.rectTransform.DOAnchorPosX(0, duration).SetEase(Ease.OutQuad);
            subjectLabel.rectTransform.DOAnchorPosX(nameLabel.preferredWidth + padding, duration).SetEase(Ease.OutQuad);
            Resize(nameLabel);
        } else {
            nameLabel.rectTransform.DOAnchorPosX(subjectLabel.preferredWidth + padding, duration).SetEase(Ease.OutQuad);
            subjectLabel.rectTransform.DOAnchorPosX(0, duration).SetEase(Ease.OutQuad);
            Resize(subjectLabel);
        }
    }

    IEnumerator ShiftRoutine(bool isSubjectShown) {
        yield return null;
        if (isSubjectShown) {
            nameLabel.rectTransform.DOAnchorPosX(0, duration).SetEase(Ease.OutQuad);
            subjectLabel.rectTransform.DOAnchorPosX(nameLabel.preferredWidth + padding, duration).SetEase(Ease.OutQuad);
            Resize(nameLabel);
        } else {
            nameLabel.rectTransform.DOAnchorPosX(subjectLabel.preferredWidth + padding, duration).SetEase(Ease.OutQuad);
            subjectLabel.rectTransform.DOAnchorPosX(0, duration).SetEase(Ease.OutQuad);
            Resize(subjectLabel);
        }
    }
}
