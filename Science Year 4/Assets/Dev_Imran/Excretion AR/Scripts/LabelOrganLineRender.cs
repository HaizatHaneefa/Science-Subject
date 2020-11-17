using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class LabelOrganLineRender : MonoBehaviour
{
    public UILineRenderer uiLineRenderer;

    public RectTransform target1;
    public RectTransform target2;
    public RectTransform canvas;
    public Vector2 point1;
    public Vector2 point2;

    Vector3[] worldSpaces = new Vector3[2];
    Vector3[] canvasSpaces = new Vector3[2];

    Vector2 refPivot;

    void Start()
    {
        // Get the pivot points
        refPivot = target1.pivot;
        //Vector2 canvasPivot = canvas.pivot;




        // // First, convert the pivot to worldspace
        // for (int i = 0; i < controlPoints.Length; i++)
        // {
        //     worldSpaces[i] = controlPoints[i].rectTransform.TransformPoint(refPivot);
        // }



        // Then, convert to canvas space


        // for (int i = 0; i < controlPoints.Length; i++)
        // {
        //     canvasSpaces[i] = canvas.InverseTransformPoint(worldSpaces[i]);
        // }

        // Calculate delta from the canvas pivot point


        // for (int i = 0; i < controlPoints.Length; i++)
        // {
        //     points[i] = new Vector2(canvasSpaces[i].x, canvasSpaces[i].y);
        // }

        // And assign the converted points to the line renderer

        // lr.Points = points;
        // lr.RelativeSize = false;
        // lr.drivenExternally = true;

        // previousPositions = new Vector2[controlPoints.Length];
        // for (int i = 0; i < controlPoints.Length; i++)
        // {
        //     previousPositions[i] = controlPoints[i].rectTransform.anchoredPosition;
        // }
    }

    void Update()
    {
        worldSpaces[0] = target1.TransformPoint(refPivot);
        worldSpaces[1] = target2.TransformPoint(refPivot);

        for (int i = 0; i < canvasSpaces.Length; i++)
            canvasSpaces[i] = canvas.InverseTransformPoint(worldSpaces[i]);

        point1 = new Vector2(canvasSpaces[0].x, canvasSpaces[0].y);
        point2 = new Vector2(canvasSpaces[1].x, canvasSpaces[1].y);
        uiLineRenderer.Points.SetValue(point1, 0);
        uiLineRenderer.Points.SetValue(point2, 1);

        uiLineRenderer.RelativeSize = false;
        uiLineRenderer.drivenExternally = true;
    }
}
