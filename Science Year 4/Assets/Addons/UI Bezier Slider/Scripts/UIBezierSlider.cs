using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI.Extensions;

// [RequireComponent(typeof(UILineRenderer))]
public class UIBezierSlider : MonoBehaviour
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> {}
    public RectTransform handle;
    [Tooltip("Maximum distance the handle can move per frame. Increase value if handle is lagging behind.")]
    public float maxDistance = 50f;
    [Tooltip("Number of segments per curve (for LUT). Increase value for more smoothness.")]
    public int lutSegments = -1;
    public bool interactable = true;
    public bool rotateHandle = true;
    private int currentLUTIndex = 0;
    public int currentIndex => currentLUTIndex;
    public FloatEvent onSet = new FloatEvent();
    // fill line stuff
    public UILineRenderer fill;
    private float segmentRatio = 1;
    private Vector2[] fillLUT;
    private List<Vector2> fillPoints = new List<Vector2>();

    // fields and accessors
    private Vector2[] _lut; // look up table
    private UILineRenderer _lineRenderer;
    public UILineRenderer lineRenderer => _lineRenderer ? _lineRenderer : _lineRenderer = GetComponent<UILineRenderer>();
    public Vector2[] lut {
        private set { _lut = value; }
        get { return (_lut != null) ? _lut : _lut = GetLUT(); }
    }

    public float Value {
        set { SetHandle(Mathf.RoundToInt(Mathf.Clamp01(value) * (lut.Length - 1))); }
        get { return (float)currentLUTIndex / (lut.Length - 1); }
    }

    void Awake()
    {
        lut = GetLUT(lutSegments);
        fillLUT = GetLUT();
        segmentRatio = (float)lutSegments / (float)lineRenderer.BezierSegmentsPerCurve;
        var handleScript = handle.gameObject.AddComponent<UIBezierSliderHandle>();
        handleScript.Initialize(this);
        lineRenderer.raycastTarget = false;
        if (fill) fill.raycastTarget = false;
    }


    /// <summary>
    /// Generates Look Up Table
    /// </summary>
    /// <param name="segments">
    /// Sets the number of segments per curve. Higher value is smoother but more computationally expensive.
    /// Negative value takes number of segments from the UI Line Renderer
    /// </param>
    /// <returns>LUT</returns>
    public Vector2[] GetLUT(int segments = -1)
    {
        BezierPath bezierPath = new BezierPath();
        bezierPath.SetControlPoints(lineRenderer.Points);
        bezierPath.SegmentsPerCurve = (segments < 0) ? lineRenderer.BezierSegmentsPerCurve : segments;
        List<Vector2> pointsLUT;
        switch (lineRenderer.BezierMode) {
        case UILineRenderer.BezierType.Basic:
            pointsLUT = bezierPath.GetDrawingPoints0();
            break;
        case UILineRenderer.BezierType.Improved:
            pointsLUT = bezierPath.GetDrawingPoints1();
            break;
        default:
            pointsLUT = bezierPath.GetDrawingPoints2();
            break;
        }
        return pointsLUT.ToArray();
    }

    /// <summary>
    /// Moves the handle based off closest distance of cursor to point on bezier line
    /// </summary>
    /// <param name="position"></param>
    /// <param name="allowPositive"></param>
    /// <param name="allowNegative"></param>
    /// <returns>Handle position</returns>
    public Vector2 OptimizedMoveHandle(Vector2 position, bool allowPositive = true, bool allowNegative = true)
    {
        float handleDistance = Vector2.Distance(lut[currentLUTIndex], position);
        float negativeDistance = (currentLUTIndex > 0) ? Vector2.Distance(lut[currentLUTIndex - 1], position) : Mathf.Infinity;
        float positiveDistance = (currentLUTIndex < lut.Length - 1) ? Vector2.Distance(lut[currentLUTIndex + 1], position) : Mathf.Infinity;

        int lastIndex, newIndex = currentLUTIndex;
        float lastDistance, sliderLength = 0f;
        
        if (handleDistance > negativeDistance && allowNegative) { // moves slider backwards
            do {
                lastIndex = newIndex--;
                sliderLength += Vector2.Distance(lut[lastIndex], lut[newIndex]); // tally the distance along the bezier
                lastDistance = Vector2.Distance(lut[newIndex], position);
            } while (sliderLength < maxDistance // limit how far the slider moves per frame
                     && newIndex > 0
                     && lastDistance > Vector2.Distance(lut[newIndex - 1], position)); // stop counting once shortest distance to cursor is found
            return SetHandle(newIndex);
        } 
        
        if (handleDistance > positiveDistance && allowPositive) { // moves slider forwards
            do {
                lastIndex = newIndex++;
                sliderLength += Vector2.Distance(lut[lastIndex], lut[newIndex]); // tally the distance along the bezier
                lastDistance = Vector2.Distance(lut[newIndex], position);
            } while (sliderLength < maxDistance // limit how far the slider moves per frame
                     && newIndex < lut.Length - 1
                     && lastDistance > Vector2.Distance(lut[newIndex + 1], position)); // stop counting once shortest distance to cursor is found
            return SetHandle(newIndex);
        }

        return lut[currentLUTIndex];
    }

    /// <summary>
    /// Sets the handle position & draws the fill line
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Handle position</returns>
    private Vector2 SetHandle(int index)
    {
        currentLUTIndex = index;
        handle.anchoredPosition = lut[index];
        RotateHandle(index);
        onSet?.Invoke(Value);
        DrawFill(index);
        return lut[index];
    }

    public void RotateHandle(int index) {
        if (!rotateHandle) {
            return;
        }
        if (index < lut.Length - 1) {
            handle.right = lut[index + 1] - handle.anchoredPosition;
        }
    }

    /// <summary>
    /// Draws the fill line
    /// </summary>
    /// <param name="index"></param>
    private void DrawFill(int index)
    {
        if (!fill) {
            return;
        }
        // add points when handle moves past
        while (fillPoints.Count * segmentRatio <= index) {
            Vector2 fillPoint = fillLUT[fillPoints.Count];
            fillPoints.Add(fillPoint);
        }
        // remove points when handle goes past backwards
        while ((fillPoints.Count - 1) * segmentRatio > index) {
            fillPoints.RemoveAt(fillPoints.Count - 1);
        }
        // set last point to follow handle
        if ((fillPoints.Count - 1) * segmentRatio < index) {
            fillPoints.Add(lut[index]);
        } else {
            fillPoints[fillPoints.Count - 1] = lut[index];
        }
        // do any necessary corrections
        for (int i = 0; i < fillPoints.Count - 1; i++) {
            if (fillPoints[i] != fillLUT[i]) {
                fillPoints[i] = fillLUT[i];
            }
        }
        fill.Points = fillPoints.ToArray();
    }
}
