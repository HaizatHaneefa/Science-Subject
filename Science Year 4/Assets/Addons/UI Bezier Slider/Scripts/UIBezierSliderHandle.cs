using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIBezierSliderHandle : MonoBehaviour, IDragHandler
{
    public UIBezierSlider slider {set; private get;}
    private RectTransform _rectTransform;
    private RectTransform _cursor;
    private RectTransform cursor {
        get {
            if (!_cursor) {
                GameObject cursorObject = new GameObject("Cursor");
                _cursor = cursorObject.AddComponent<RectTransform>();
                cursorObject.transform.SetParent(transform.parent);
            }
            return _cursor;
        }
    }
    public RectTransform rectTransform => _rectTransform ? _rectTransform : _rectTransform = GetComponent<RectTransform>();
    
    /// <summary>
    /// Sets the slider reference and moves the handle into position
    /// </summary>
    /// <param name="slider"></param>
    public void Initialize (UIBezierSlider slider) {
        this.slider = slider;
        rectTransform.anchoredPosition = slider.lut[slider.currentIndex];
        slider.Value = slider.currentIndex;
    }

    void OnEnable() {
        if (slider) 
            slider.interactable = false;
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(Vector3.one, 0.3f)
            .SetEase(Ease.OutBack)
            .OnComplete(() => {
                if (slider)
                    slider.interactable = true;
            });
    }

    public void OnDrag (PointerEventData eventData) {
        if (!slider.interactable) {
            return;
        }
        cursor.position = eventData.position; // move the RectTransform of the cursor
        slider.OptimizedMoveHandle(cursor.anchoredPosition); // use the cursor's anchoredPosition to avoid conversion issues
    }
}
