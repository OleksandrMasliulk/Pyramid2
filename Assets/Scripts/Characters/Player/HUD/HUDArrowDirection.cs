using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDArrowDirection : MonoBehaviour
{
    [SerializeField] private Image leftSegment;
    [SerializeField] private Image rightSegment;
    [SerializeField] private Image upSegment;
    [SerializeField] private Image downSegment;
    private Image highlightedSegment;

    private Vector3 circleStartpos;
    [SerializeField] private RectTransform circle;
    [SerializeField] private float circleOffsetDistance;

    private Vector3 mousePosTemp;

    private void OnEnable()
    {
        circleStartpos = circle.position;
        mousePosTemp = Input.mousePosition;

        UnhighlightSegment();
        highlightedSegment = null;
    }

    private void Update()
    {
        circle.position = circleStartpos + (MouseUtils.GetMouseDragDirection(mousePosTemp, Input.mousePosition) * circleOffsetDistance);

        string mouseDragDirection = MouseUtils.GetMouseDragDirectionString(mousePosTemp, Input.mousePosition);
        if (mouseDragDirection == "Left")
        {
            HighlightSegment(leftSegment);
        } 
        else if (mouseDragDirection == "Right")
        {
            HighlightSegment(rightSegment);
        }
        else if (mouseDragDirection == "Up")
        {
            HighlightSegment(upSegment);
        }
        else if (mouseDragDirection == "Down")
        {
            HighlightSegment(downSegment);
        }
        else
        {
            UnhighlightSegment();
        }
    }

    private void HighlightSegment(Image segment)
    {
        UnhighlightSegment();
        highlightedSegment = segment;
        segment.GetComponent<IHighlight>().Highlight();
    }

    private void UnhighlightSegment()
    {
        if (highlightedSegment != null)
        {
            highlightedSegment.GetComponent<IHighlight>().UnHighlight();
        }
    }
}
