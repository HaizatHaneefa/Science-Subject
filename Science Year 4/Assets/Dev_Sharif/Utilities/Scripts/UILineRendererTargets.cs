using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.Extensions {
[RequireComponent(typeof(UILineRenderer))]
public class UILineRendererTargets : MonoBehaviour
{
    public RectTransform[] rectTransforms;

    void OnValidate() {
        Vector2[] points = new Vector2[rectTransforms.Length];
        for (int i = 0; i < rectTransforms.Length; i++) {
            points[i] = rectTransforms[i].anchoredPosition;
        }
    }
}
}
