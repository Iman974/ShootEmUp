using UnityEngine;

public struct Matrix2x2 {

    private float column0_row0;
    private float column0_row1;
    private float column1_row0;
    private float column1_row1;

    private Matrix2x2(float c0_r0, float c0_r1, float c1_r0, float c1_r1) {
        column0_row0 = c0_r0;
        column0_row1 = c0_r1;
        column1_row0 = c1_r0;
        column1_row1 = c1_r1;
    }

    public static Matrix2x2 CreateRotation(float radians) {
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        return new Matrix2x2(cos, sin, -sin, cos);
    }

    public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector) {
        return new Vector2 {
            x = (matrix.column0_row0 * vector.x) + (matrix.column1_row0 * vector.y),
            y = (matrix.column0_row1 * vector.x) + (matrix.column1_row1 * vector.y)
        };
    }
}
