using UnityEngine;

namespace Ellyality
{
    /// <summary>
    /// Utility for math calculation
    /// </summary>
    public static partial class MathE
    {
        /// <summary>
        /// Quaternion calculation
        /// </summary>
        public static class Quaternion
        {
            /// <summary>
            /// Change to target world quaternion to parent local quaternion
            /// </summary>
            public static UnityEngine.Quaternion WorldToLocal(UnityEngine.Quaternion parent, UnityEngine.Quaternion target)
            {
                return UnityEngine.Quaternion.Inverse(parent) * target;
            }
            /// <summary>
            /// Change to target local quaternion to parent world quaternion
            /// </summary>
            public static UnityEngine.Quaternion LocalToWorld(UnityEngine.Quaternion parent, UnityEngine.Quaternion target)
            {
                return parent * target;
            }
            /// <summary>
            /// Mathematics correct way to smooth damp quaternion <br />
            /// Use Quaternion.Slerp method to do the transition
            /// </summary>
            /// <param name="source">From</param>
            /// <param name="target">To</param>
            public static UnityEngine.Quaternion SmoothDamp(UnityEngine.Quaternion source, UnityEngine.Quaternion target, ref float velocity, float smoothTime)
            {
                float delta = UnityEngine.Quaternion.Angle(source, target);
                if(delta > 0f)
                {
                    var t = Mathf.SmoothDampAngle(delta, 0.0f, ref velocity, smoothTime);
                    t = 1.0f - t / delta;
                    return UnityEngine.Quaternion.Slerp(source, target, t);
                }
                else
                {
                    return source;
                }
            }
        }

        /// <summary>
        /// Transform 0 - 360 base angle to -180 - 180
        /// </summary>
        /// <param name="a">Angle</param>
        /// <returns></returns>
        public static float RotationAngle360ToPositionNegative180(float a)
        {
            return a > 180 ? -(360 - a) : a;
        }
    }
}
