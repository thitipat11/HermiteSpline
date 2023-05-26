using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermiteSpline
{
    private Vector2[] controlPoints;

    public HermiteSpline(Vector2[] controlPoints)
    {
        this.controlPoints = controlPoints;
    }

    public Vector2 GetPoint(float t)
    {
        int segmentCount = controlPoints.Length - 1;
        float segmentT = t * segmentCount;

        int segmentIndex = Mathf.FloorToInt(segmentT);
        segmentT -= segmentIndex;

        if (segmentIndex >= controlPoints.Length - 1)
        {
            segmentIndex = controlPoints.Length - 2;
            segmentT = 1f;
        }

        Vector2 startPoint = controlPoints[segmentIndex];
        Vector2 startTangent = GetOutTangent(segmentIndex);

        Vector2 endPoint = controlPoints[segmentIndex + 1];
        Vector2 endTangent = GetInTangent(segmentIndex + 1);

        return HermiteInterpolate(startPoint, startTangent, endPoint, endTangent, segmentT);
    }

    private Vector2 GetOutTangent(int index)
    {
        int previousIndex = Mathf.Max(0, index - 1);
        int nextIndex = Mathf.Min(index + 1, controlPoints.Length - 1);

        return (controlPoints[nextIndex] - controlPoints[previousIndex]) * 0.5f;
    }

    private Vector2 GetInTangent(int index)
    {
        int previousIndex = Mathf.Max(0, index - 1);
        int nextIndex = Mathf.Min(index + 1, controlPoints.Length - 1);

        return (controlPoints[index] - controlPoints[previousIndex]) * 0.5f;
    }

    private Vector2 HermiteInterpolate(Vector2 startPoint, Vector2 startTangent, Vector2 endPoint, Vector2 endTangent, float t)
    {
        float t2 = t * t;
        float t3 = t2 * t;

        float h1 = 2 * t3 - 3 * t2 + 1;
        float h2 = -2 * t3 + 3 * t2;
        float h3 = t3 - 2 * t2 + t;
        float h4 = t3 - t2;

        return h1 * startPoint + h2 * endPoint + h3 * startTangent + h4 * endTangent;
    }
}