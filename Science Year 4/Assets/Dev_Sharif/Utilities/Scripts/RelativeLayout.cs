using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(LayoutElement))]
public class RelativeLayout : MonoBehaviour
{
    private LayoutElement _layoutElement;
    private LayoutElement layoutElement {
        get {
            if (_layoutElement == null) _layoutElement = GetComponent<LayoutElement>();
            return _layoutElement;
        }
    }

    [Header("Sources")]
    public RectTransform flexibleHeight;
    public float addedFlexibleHeight = 0f;
    public RectTransform flexibleWidth;
    public float addedFlexibleWidth = 0f;
    public RectTransform minHeight;
    public float addedMinHeight = 0f;
    public RectTransform minWidth;
    public float addedMinWidth = 0f;
    public RectTransform preferredHeight;
    public float myPreferredHeight = 0f;
    public RectTransform preferredWidth;
    public float myPreferredWidth = 0f;


    void Update()
    {
        if (!Application.isPlaying && Application.isEditor) {
            Set();
        }
    }

    public void Set()
    {
        if (flexibleHeight != null) {
            layoutElement.flexibleHeight = LayoutUtility.GetFlexibleHeight(flexibleHeight) + addedFlexibleHeight;
        }
        if (flexibleWidth != null) {
            layoutElement.flexibleWidth = LayoutUtility.GetFlexibleWidth(flexibleWidth) + addedFlexibleWidth;
        }
        if (minHeight != null) {
            layoutElement.minHeight = LayoutUtility.GetMinHeight(minHeight) + addedMinHeight;
        }
        if (minWidth != null) {
            layoutElement.minWidth = LayoutUtility.GetMinWidth(minWidth) + addedMinWidth;
        }
        if (preferredHeight != null) {
            layoutElement.preferredHeight = Mathf.Max(LayoutUtility.GetPreferredHeight(preferredHeight), myPreferredHeight);
        }
        if (preferredWidth != null) {
            layoutElement.preferredWidth = Mathf.Max(LayoutUtility.GetPreferredWidth(preferredWidth), myPreferredWidth);
        }
    }
}
