using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    public CanvasGroup canvasGroup {private set; get;}
    [SerializeField] float duration = 0.5f;
    [SerializeField] Ease ease = Ease.Linear;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void DOFade(float value) {
        canvasGroup.blocksRaycasts = value >= 1;
        canvasGroup.DOFade(value, duration).SetEase(ease);
    }
}
