using System.Collections;
using UnityEngine;

namespace EasyEase {
    /// <summary>
    /// Use EaseProperty to add a ease type dropdown to the Unity Inspector
    /// 
    /// EaseProperty allows you to use this in a Unity inspector and it just looks like an enum dropdown
    /// Looking up the actual function from the enum value is slow so memoize the function delegate.
    /// </summary>
    [System.Serializable]
    public class EaseProperty {
        [SerializeField]
        public EaseType PropType;
        private Easy.Func _Func;
        public Easy.Func Func {
            get {
                if (_Func == null) {
                    var propName = PropType.ToString();
                    var propInfo = typeof(Easy).GetProperty(propName);
                    _Func = propInfo.GetValue(null, null) as Easy.Func;
                }
                return _Func;
            }
        }
        public static implicit operator Easy.Func(EaseProperty p) {
            return p.Func;
        }
        public static implicit operator EaseProperty(EaseType t) {
            return new EaseProperty() { PropType = t };
        }
    }

    /// <summary>
    /// Don't use this directly. Use EaseProperty instead.
    /// </summary>
    public enum EaseType {
        Linear,
        SmoothStart2,
        SmoothStart3,
        SmoothStart4,
        SmoothStart5,
        SmoothStop2,
        SmoothStop3,
        SmoothStop4,
        SmoothStop5,
        SmoothStartStop2,
        SmoothStartStop3,
        SmoothStartStop4,
        SmoothStartStop5,
        ExpStart,
        ExpStart2,
        ExpStart4,
        ExpStop,
        ExpStop2,
        ExpStop4,
        ExpStartStop,
        ExpStartStop2,
        ExpStartStop4,
        Hermite,
        Windup,
        Windup2,
        Windup3,
        OverShoot,
        OverShoot2,
        OverShoot3,
        ElasticStop,
        ElasticStop2,
        ElasticStop3,
        ElasticStart,
        ElasticStart2,
        ElasticStart3,
        BounceStart,
        BounceStart2,
        BounceStart3,
        BounceStop,
        BounceStop2,
        BounceStop3
    }

    public static class Easy {
        public delegate float Func(float t);

        public static float Ease(float a, float b, float t, Func ease) {
            if (t <= 0f) { return a; } else if (t >= 1f) { return b; }
            float val = (b - a) * ease(t) + a;
            return val;
        }

        public static Vector3 Ease(Vector3 a, Vector3 b, float t, Func ease) {
            if (t <= 0f) { return a; } else if (t >= 1f) { return b; }
            return (b - a) * ease(t) + a;
        }

        public static Quaternion Ease(Quaternion a, Quaternion b, float t, Func ease) {
            if (t <= 0f) { return a; } else if (t >= 1f) { return b; }
            return Quaternion.LerpUnclamped(a, b, ease(t));
        }

        public static Color Ease(Color a, Color b, float t, Func ease) {
            if (t <= 0f) { return a; } else if (t >= 1f) { return b; }
            float easeVal = ease(t);
            return Color.Lerp(a, b, easeVal);
        }

        public static Func CrossFade(Func r, Func s) {
            return (t) => {
                float q = t;
                return (1 - q) * r(t) + q * s(t);
            };
        }

        public static Func InOut(Func r, Func s) {
            return (t) => {
                if (t < 0.5f) {
                    t *= 2.0f;
                    return r(t) * 0.5f;
                } else {
                    t = (t - 0.5f) * 2.0f;
                    return s(t) * 0.5f + 0.5f;
                }
            };
        }

        public static Func Blend(Func r, Func s, float blend) {
            if (blend <= 0) {
                return (t) => {
                    return r(t);
                };
            } else if (blend >= 1.0f) {
                return (t) => {
                    return s(t);
                };
            } else {
                return (t) => {
                    return (1 - blend) * r(t) + blend * s(t);
                };
            }
        }

        public static Func Linear {
            get {
                return (t) => {
                    return t;
                };
            }
        }

        public static Func SmoothStart2 {
            get {
                return (t) => {
                    return t * t;
                };
            }
        }

        public static Func SmoothStart3 {
            get {
                return t => {
                    return t * t * t;
                };
            }
        }

        public static Func SmoothStart4 {
            get {
                return (t) => {
                    return t * t * t * t;
                };
            }
        }

        public static Func SmoothStart5 {
            get {
                return (t) => {
                    return t * t * t * t * t;;
                };
            }
        }

        public static Func SmoothStop2 {
            get {
                return (t) => {
                    return 1 - (1 - t) * (1 - t);
                };
            }
        }

        public static Func SmoothStop3 {
            get {
                return (t) => {
                    return 1 - (1 - t) * (1 - t) * (1 - t);
                };
            }
        }

        public static Func SmoothStop4 {
            get {
                return (t) => {
                    return 1 - (1 - t) * (1 - t) * (1 - t) * (1 - t);
                };
            }
        }

        public static Func SmoothStop5 {
            get {
                return (t) => {
                    return 1 - (1 - t) * (1 - t) * (1 - t) * (1 - t) * (1 - t);
                };
            }
        }

        public static Func SmoothStartStop2 {
            get {
                return InOut(SmoothStart2, SmoothStop2);
            }
        }

        public static Func SmoothStartStop3 {
            get {
                return InOut(SmoothStart3, SmoothStop3);
            }
        }

        public static Func SmoothStartStop4 {
            get {
                return InOut(SmoothStart4, SmoothStop4);
            }
        }

        public static Func SmoothStartStop5 {
            get {
                return InOut(SmoothStart5, SmoothStop5);
            }
        }

        public static Func ExpStart {
            get {
                return (t) => {
                    return Mathf.Pow(3, 5 * (t - 1));
                };
            }
        }

        public static Func ExpStart2 {
            get {
                return (t) => {
                    float q = ExpStart(t);
                    return q * q;
                };
            }
        }

        public static Func ExpStart4 {
            get {
                return (t) => {
                    float q = ExpStart(t);
                    return q * q * q * q;
                };
            }
        }

        public static Func ExpStop {
            get {
                return (t) => {
                    return -Mathf.Pow(3, -5 * t) + 1;
                };
            }
        }

        public static Func ExpStop2 {
            get {
                return (t) => {
                    float q = ExpStop(t);
                    return q * q;
                };
            }
        }

        public static Func ExpStop4 {
            get {
                return (t) => {
                    float q = ExpStop(t);
                    return q * q * q * q;
                };
            }
        }

        public static Func ExpStartStop {
            get {
                return CrossFade(ExpStart, ExpStop);
            }
        }

        public static Func ExpStartStop2 {
            get {
                return CrossFade(ExpStart2, ExpStop2);
            }
        }

        public static Func ExpStartStop4 {
            get {
                return CrossFade(ExpStart4, ExpStop4);
            }
        }

        /*
      t  - in interval <0..1>
      p0 - Start position
      p1 - End position
      m0 - Start tangent
      m1 - End tangent
    */
        private static float CubicHermite(float t, float p0, float p1, float m0, float m1) {
            float t2 = t * t;
            float t3 = t2 * t;
            return (2 * t3 - 3 * t2 + 1) * p0 + (t3 - 2 * t2 + t) * m0 + (-2 * t3 + 3 * t2) * p1 + (t3 - t2) * m1;
        }

        private static float CubicHermite01(float t, float m0, float m1) {
            float t2 = t * t;
            float t3 = t2 * t;
            return (t3 - 2 * t2 + t) * m0 + (-2 * t3 + 3 * t2) + (t3 - t2) * m1;
        }

        public static Func Hermite {
            get {
                return (t) => {
                    return CubicHermite01(t, 0, 0);
                };
            }
        }

        public static Func Windup {
            get {
                return (t) => {
                    return CubicHermite01(t, -1.0f, 0);
                };
            }
        }

        public static Func Windup2 {
            get {
                return (t) => {
                    return CubicHermite01(t, -2.0f, 0);
                };
            }
        }

        public static Func Windup3 {
            get {
                return (t) => {
                    return CubicHermite01(t, -3.0f, 0);
                };
            }
        }

        public static Func OverShoot {
            get {
                return (t) => {
                    return CubicHermite01(t, 0, -1.0f);
                };
            }
        }

        public static Func OverShoot2 {
            get {
                return (t) => {
                    return CubicHermite01(t, 0, -2.0f);
                };
            }
        }

        public static Func OverShoot3 {
            get {
                return (t) => {
                    return CubicHermite01(t, 0, -3.0f);
                };
            }
        }

        public static Func ElasticStop {
            get {
                float p = 0.5f;
                return (t) => {
                    return Mathf.Pow(2, -10 * t) * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p) + 1;
                };
            }
        }

        public static Func ElasticStop2 {
            get {
                float p = 0.3f;
                return (t) => {
                    return Mathf.Pow(2, -10 * t) * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p) + 1;
                };
            }
        }

        public static Func ElasticStop3 {
            get {
                float p = 0.15f;
                return (t) => {
                    return Mathf.Pow(2, -10 * t) * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p) + 1;
                };
            }
        }

        public static Func ElasticStart {
            get {
                return (t) => {
                    return 1.0f - ElasticStop(1.0f - t);
                };
            }
        }

        public static Func ElasticStart2 {
            get {
                return (t) => {
                    return 1.0f - ElasticStop2(1.0f - t);
                };
            }
        }

        public static Func ElasticStart3 {
            get {
                return (t) => {
                    return 1.0f - ElasticStop3(1.0f - t);
                };
            }
        }

        public static Func BounceStart {
            get {
                return (t) => {
                    float p = 0.7f;
                    return Mathf.Abs(t * t * t * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p));
                };
            }
        }

        public static Func BounceStart2 {
            get {
                return (t) => {
                    float p = 0.5f;
                    return Mathf.Abs(t * t * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p));
                };
            }
        }

        public static Func BounceStart3 {
            get {
                return (t) => {
                    float p = 0.4f;
                    return Mathf.Abs(t * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p));
                };
            }
        }

        public static Func BounceStop {
            get {
                return (t) => {
                    return 1.0f - BounceStart(t - 1.0f);
                };
            }
        }

        public static Func BounceStop2 {
            get {
                return (t) => {
                    return 1.0f - BounceStart2(t - 1.0f);
                };
            }
        }

        public static Func BounceStop3 {
            get {
                return (t) => {
                    return 1.0f - BounceStart3(t - 1.0f);
                };
            }
        }
    }
}