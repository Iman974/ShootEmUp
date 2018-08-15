using UnityEngine;

public static class VectorUtility {

    public static Vector2 Clamp(Vector2 vector, float minX, float maxX, float minY, float maxY) {
        if (vector.x < minX) {
            vector.x = minX;
        } else if (vector.x > maxX) {
            vector.x = maxX;
        }

        if (vector.y < minY) {
            vector.y = minY;
        } else if (vector.y > maxY) {
            vector.y = maxY;
        }

        return vector;
    }
}
