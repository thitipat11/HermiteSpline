using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermiteSplineGenerator : MonoBehaviour
{
    public Vector2[] controlPoints;
    public int resolution = 10;

    private void Start()
    {
        GenerateSpline();
    }

    private void OnValidate()
    {
        GenerateSpline();
    }

    public void GenerateSpline()
    {
        //if (controlPoints.Length < 4)
        //{
        //    Debug.LogError("Hermite Spline requires exactly 4 control points.");
        //    return;
        //}

        HermiteSpline spline = new HermiteSpline(controlPoints);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float t = (float)i / (resolution - 1);
            Vector2 position = spline.GetPoint(t);
            lineRenderer.SetPosition(i, position);
        }
    }
}