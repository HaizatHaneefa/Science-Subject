using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBezierControlPoint : MonoBehaviour
{
    private Image _image;
    private Image image => _image ? _image : _image = GetComponent<Image>();
    private RectTransform _rectTransform;
    public RectTransform rectTransform
    {
        private set { _rectTransform = value; }
        get { return _rectTransform ? _rectTransform : _rectTransform = GetComponent<RectTransform>(); }
    }

    void Awake() {
        image.enabled = false;
    }
}
