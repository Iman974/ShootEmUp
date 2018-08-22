using UnityEngine;

public static class VectorUtility {

    public static Vector2 Clamp(Vector2 vector, float xMin, float xMax, float yMin, float yMax) {
        if (vector.x < xMin) {
            vector.x = xMin;
        } else if (vector.x > xMax) {
            vector.x = xMax;
        }

        if (vector.y < yMin) {
            vector.y = yMin;
        } else if (vector.y > yMax) {
            vector.y = yMax;
        }

        return vector;
    }

    public static Vector2 Clamp(Vector2 vector, Rect limit) {
        return Clamp(vector, limit.xMin, limit.xMax, limit.yMin, limit.yMax);
    }
}
