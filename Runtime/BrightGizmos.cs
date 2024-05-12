using UnityEngine;

namespace BrightToolingRuntime
{
    /// <summary>
    /// Extends <see cref="Gizmos"/> with quality-of-life methods.
    /// </summary>
    public sealed class BrightGizmos
    {
        private BrightGizmos() { }

        public static void DrawArrow(Vector3 from, Vector3 direction, float headLength = 0.25f, float headAngle = 20.0f)
        {
            DrawArrow(from, direction, Color.blue, headLength, headAngle);
        }

        public static void DrawArrow(Vector3 from, Vector3 direction, Color color, float headLength = 0.25f, float headAngle = 20.0f)
        {
#if UNITY_EDITOR
            Gizmos.color = color;
            Gizmos.DrawRay(from, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(180 + headAngle, 0, 180 + headAngle) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(180 - headAngle, 0, 180 - headAngle) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(from + direction, right * headLength);
            Gizmos.DrawRay(from + direction, left * headLength);
#endif
        }


        public static void DrawDashedSquare(Vector2 min, Vector2 max, Color color, int segments)
        {
            Vector2[] points = new Vector2[4];
            points[0] = new Vector2(min.x, min.y);
            points[1] = new Vector2(min.x, max.y);
            points[2] = new Vector2(max.x, max.y);
            points[3] = new Vector2(max.x, min.y);

            Gizmos.color = color;
            DrawDashedLine(points[0], points[1]);
            DrawDashedLine(points[1], points[2]);
            DrawDashedLine(points[2], points[3]);
            DrawDashedLine(points[3], points[0]);

        }

        private static float DASH_LENGTH = 0.15f;
        private static float GAP_LENGTH = 0.1f;

        public static void DrawWireCubeWithDashedLines(Vector3 center, Vector3 size)
        {
            Vector3 topLeft = center;
            topLeft.x -= size.x / 2f;
            topLeft.y -= size.y / 2f;
            Vector3 topRight = center;
            topRight.x += size.x / 2f;
            topRight.y -= size.y / 2f;
            Vector3 botLeft = center;
            botLeft.x -= size.x / 2f;
            botLeft.y += size.y / 2f;
            Vector3 botRight = center;
            botRight.x += size.x / 2f;
            botRight.y += size.y / 2f;

            DrawDashedLine(topLeft, topRight);
            DrawDashedLine(topRight, botRight);
            DrawDashedLine(botRight, botLeft);
            DrawDashedLine(botLeft, topLeft);
        }

        public static void DrawDashedLine(Vector3 startPoint, Vector3 endPoint)
        {
            Vector3 direction = (endPoint - startPoint).normalized;
            float distance = Vector3.Distance(startPoint, endPoint);
            int dashCount = Mathf.FloorToInt(distance / (DASH_LENGTH + GAP_LENGTH));

            for (int i = 0; i < dashCount; i++)
            {
                Vector3 dashStart = startPoint + direction * (i * (DASH_LENGTH + GAP_LENGTH));
                Vector3 dashEnd = dashStart + direction * DASH_LENGTH;
                Gizmos.DrawLine(dashStart, dashEnd);
            }
        }

        public void DrawDashedLine(params Vector3[] points)
        {
            if (points.Length < 2)
                return;

            for (int i = 0; i < points.Length - 1; i++)
            {
                Vector3 startPoint = points[i];
                Vector3 endPoint = points[i + 1];

                Vector3 direction = (endPoint - startPoint).normalized;
                float distance = Vector3.Distance(startPoint, endPoint);
                int dashCount = Mathf.FloorToInt(distance / (DASH_LENGTH + GAP_LENGTH));

                for (int j = 0; j < dashCount; j++)
                {
                    Vector3 dashStart = startPoint + direction * (j * (DASH_LENGTH + GAP_LENGTH));
                    Vector3 dashEnd = dashStart + direction * DASH_LENGTH;
                    Gizmos.DrawLine(dashStart, dashEnd);
                }
            }
        }
    }
}