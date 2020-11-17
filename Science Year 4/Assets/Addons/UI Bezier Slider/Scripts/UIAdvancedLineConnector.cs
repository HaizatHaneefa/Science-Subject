#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.UI.Extensions
{
    [AddComponentMenu("UI/Extensions/UI Line Connector")]
    [RequireComponent(typeof(UILineRenderer))]
    [ExecuteInEditMode]
    public class UIAdvancedLineConnector : MonoBehaviour
    {
        #if UNITY_EDITOR
        private Vector2[] previousPositions;
        private RectTransform _canvas;
        private RectTransform canvas => _canvas ? _canvas : _canvas = GetComponentInParent<RectTransform>().GetParentCanvas().GetComponent<RectTransform>();
        private RectTransform _rt;
        public RectTransform rt => _rt ? _rt : _rt = GetComponent<RectTransform>();
        private UILineRenderer _lr;
        public UILineRenderer lr => _lr ? _lr : _lr = GetComponent<UILineRenderer>();
        public UIBezierControlPoint[] controlPoints {private set; get;}
        private int previousChildCount = 0;

        void Update() 
        {
            if (Application.isPlaying) {
                return;
            }
            UpdateLine();
            if (previousChildCount == transform.childCount) {
                return;
            }
            controlPoints = GetComponentsInChildren<UIBezierControlPoint>();
            previousChildCount = transform.childCount;
        }

        void UpdateLine()
        {
            if (controlPoints == null || controlPoints.Length < 1)
            {
                return;
            }
            //Performance check to only redraw when the child controlPoints move
            if (previousPositions != null && previousPositions.Length == controlPoints.Length)
            {
                bool updateLine = false;
                for (int i = 0; i < controlPoints.Length; i++)
                {
                    if (!updateLine && previousPositions[i] != controlPoints[i].rectTransform.anchoredPosition)
                    {
                        updateLine = true;
                    }
                }
                if (!updateLine) return;
            }

            // Get the pivot points
            Vector2 thisPivot = rt.pivot;
            Vector2 canvasPivot = canvas.pivot;

            // Set up some arrays of coordinates in various reference systems
            Vector3[] worldSpaces = new Vector3[controlPoints.Length];
            Vector3[] canvasSpaces = new Vector3[controlPoints.Length];
            Vector2[] points = new Vector2[controlPoints.Length];

            // First, convert the pivot to worldspace
            for (int i = 0; i < controlPoints.Length; i++)
            {
                worldSpaces[i] = controlPoints[i].rectTransform.TransformPoint(thisPivot);
            }

            // Then, convert to canvas space
            for (int i = 0; i < controlPoints.Length; i++)
            {
                canvasSpaces[i] = canvas.InverseTransformPoint(worldSpaces[i]);
            }

            // Calculate delta from the canvas pivot point
            for (int i = 0; i < controlPoints.Length; i++)
            {
                points[i] = new Vector2(canvasSpaces[i].x, canvasSpaces[i].y);
            }

            // And assign the converted points to the line renderer
            lr.Points = points;
            lr.RelativeSize = false;
            lr.drivenExternally = true;

            previousPositions = new Vector2[controlPoints.Length];
            for (int i = 0; i < controlPoints.Length; i++)
            {
                previousPositions[i] = controlPoints[i].rectTransform.anchoredPosition;
            }
        }
        #endif
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(UIAdvancedLineConnector))]
    public class UIAdvancedLineConnectorEditor : Editor {
        void OnSceneGUI() {
            UIAdvancedLineConnector script = (UIAdvancedLineConnector)target;
            DrawBezierHandles(script);
        }

        void DrawBezierHandles(UIAdvancedLineConnector script) {
            //todo
            if (script.lr.BezierMode == UILineRenderer.BezierType.None || script.controlPoints == null) {
                return;
            }
            //todo end
            Handles.color = Color.green;
            int curveCount = script.controlPoints.Length / 3;
            // Debug.Log($"curveCount {curveCount}");
            for (int i = curveCount; i > 0 ; i--) {
                int index = i * 3;
                Vector3 pos0 = script.controlPoints[index - 3].transform.position;
                Vector3 pos1 = script.controlPoints[index - 2].transform.position;
                Vector3 pos2 = script.controlPoints[index - 1].transform.position;
                Vector3 pos3 = script.controlPoints[index].transform.position;
                Handles.DrawLine(pos0, pos1);
                Handles.DrawLine(pos2, pos3);
            }
        }
    }
    #endif
}