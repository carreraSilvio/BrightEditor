using UnityEngine;

namespace BrightLib.BrightEditing
{
    /// <summary>
    /// Extends <see cref="Gizmos"/> with quality-of-life methods.
    /// </summary>
    public sealed class BrightGizmos
    {
        private BrightGizmos() { }

        public static void DrawArrow(Vector3 from, Vector3 direction, float headLength = 0.25f, float headAngle = 20.0f)
        {
#if UNITY_EDITOR
            Gizmos.DrawRay(from, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(180 + headAngle, 0, 180 + headAngle) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(180 - headAngle, 0, 180 - headAngle) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(from + direction, right * headLength);
            Gizmos.DrawRay(from + direction, left * headLength);
#endif
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="pieces"></param>
        public static void DrawDashedLine(Vector3 from, Vector3 to, int pieces = 2)
        {
            var direction = to - from;
            direction = direction.normalized;

            var localFrom = from;



        }
    }
}