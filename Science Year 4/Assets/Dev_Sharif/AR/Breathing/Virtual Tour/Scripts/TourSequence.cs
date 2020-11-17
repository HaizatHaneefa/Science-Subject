using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class TourSequence : MonoBehaviour
{
    public UnityEvent onShow;
    public UnityEvent onHide;
    public RectTransform panel;

    [HideInInspector] public TourManager manager;

    bool isShowing = false;

    void Awake() {
        transform.localScale = Vector3.zero;
        // Show();
    }

    void OnEnable() {
        panel?.gameObject?.SetActive(true);
    }

    void OnDisable() {
        panel?.gameObject?.SetActive(false);
    }

    public void Show(bool status = true) {
        isShowing = status;
        if (isShowing) {
            transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            onShow?.Invoke();
        } else {
            Hide();
        }
    }

    public void Hide() {
        isShowing = false;
        transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InCubic).OnComplete(() => gameObject.SetActive(false));
        onHide?.Invoke(); 
    }

    public void ToggleShow() {
        Show(!isShowing);
    }
}
