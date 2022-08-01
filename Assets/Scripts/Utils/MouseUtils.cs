using UnityEngine;

public static class MouseUtils {
    public static Vector3 GetMouseDragDirection(Vector3 startPoint, Vector3 endPoint) {
        Vector3 direction = (endPoint - startPoint).normalized;

        return direction;
    }

    public static string GetMouseDragDirectionString(Vector3 startPoint, Vector3 endPoint) {
        float xDiff = Mathf.Abs(endPoint.x - startPoint.x);
        float yDiff = Mathf.Abs(endPoint.y - startPoint.y);
        if (xDiff > yDiff) 
            if (endPoint.x > startPoint.x)
                return "Right";
            else
                return "Left";
        else if (xDiff < yDiff)
            if (endPoint.y > startPoint.y)
                return "Up";
            else
                return "Down";
        else
            return null;
    }
}
