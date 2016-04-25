using UnityEngine;
using System.Collections;

public class SimpleEase : MonoBehaviour
{

    public delegate float EaseFunc(float a, float b, float t);

    public static float Ease(float a, float b, float t, EaseFunc ease)
    {

        float val = ease(a, b, Mathf.Clamp01(t));
        return val;
    }

    public static Vector3 Ease(Vector3 a, Vector3 b, float t, EaseFunc ease)
    {
        float easeVal = ease(0, 1, t);
        return (b - a) * easeVal + a;
    }

    public static Quaternion Ease(Quaternion a, Quaternion b, float t, EaseFunc ease)
    {
        float easeVal = ease(0, 1, t);
        return Quaternion.Slerp(a, b, easeVal);
    }

    public static Color Ease(Color a, Color b, float t, EaseFunc ease)
    {
        float easeVal = ease(0, 1, t);
        return Color.Lerp(a, b, easeVal);
    }

    public static EaseFunc Linear
    {
        get
        {
            return (a, b, t) =>
            {
                return a * (1f - t) + b * t;
            };
        }
    }

    public static EaseFunc EaseIn
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * t * t + a;
            };
        }
    }

    public static EaseFunc EaseInCubic
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * t * t * t + a;
            };
        }
    }

    public static EaseFunc EaseInQuartic
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * t * t * t * t + a;
            };
        }
    }

    public static EaseFunc EaseInQuintic
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * t * t * t * t * t + a;
            };
        }
    }

    public static EaseFunc EaseOut
    {
        get
        {
            return (a, b, t) =>
            {
                return -(b - a) * t * (t - 2f) + a;
            };
        }
    }

    public static EaseFunc EaseOutCubic
    {
        get
        {
            return (a, b, t) =>
            {
                t--;
                return (b - a) * t * t * t + b + a;
            };
        }
    }

    public static EaseFunc EaseOutQuartic
    {
        get
        {
            return (a, b, t) =>
            {
                t--;
                return -(b - a) * t * t * t * t + b + a;
            };
        }
    }

    public static EaseFunc EaseOutQuintic
    {
        get
        {
            return (a, b, t) =>
            {
                t--;
                return (b - a) * t * t * t * t * t + b + a;
            };
        }
    }

    public static EaseFunc EaseInOut
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseIn(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOut(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInOutCubic
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInCubic(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutCubic(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInOutQuartic
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInQuartic(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutQuartic(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInOutQuintic
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInQuintic(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutQuintic(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInSine
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * Mathf.Sin(t * Mathf.PI * 0.5f) + a;
            };
        }
    }

    public static EaseFunc EaseOutSine
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * (Mathf.Sin((t - 1) * Mathf.PI * 0.5f) + a + 1f) + a;
            };
        }
    }

    public static EaseFunc EaseInOutSine
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInSine(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutSine(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInExp
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * Mathf.Pow(2, 10 * (t - 1)) + a;
            };
        }
    }

    public static EaseFunc EaseOutExp
    {
        get
        {
            return (a, b, t) =>
            {
                return -(b - a) * Mathf.Pow(2, 10 * (-t)) + b + a;
            };
        }
    }

    public static EaseFunc EaseInOutExp
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInExp(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutExp(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }

    public static EaseFunc EaseInOvershoot
    {
        get
        {
            return (a, b, t) =>
            {
                const float s = 1.70158f;
                return (b - a) * t * t * ((s + 1) * t - s) + a;
            };
        }
    }

    public static EaseFunc EaseOutOvershoot
    {
        get
        {
            return (a, b, t) =>
            {
                const float s = 1.70158f;
                float q = t - 1f;
                return (b - a) * q * q * ((s + 1) * q + s) + b + a;
            };
        }
    }

    public static EaseFunc EaseInOutOvershoot
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = EaseInOvershoot(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = EaseOutOvershoot(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }
}
