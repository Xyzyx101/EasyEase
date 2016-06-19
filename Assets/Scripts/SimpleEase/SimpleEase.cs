using UnityEngine;
using System.Collections;

public class SimpleEase : MonoBehaviour
{
    public delegate float EaseFunc(float a, float b, float t);

    public static float Ease(float a, float b, float t, EaseFunc ease)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        float val = ease(a, b, t);
        return val;
    }

    public static float CrossFade(float a, float b, float t, EaseFunc from, EaseFunc to)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        float fromVal = from(a, b, t);
        float toVal = to(a, b, t);
        float tFactor = -((t - 1f) * (t - 1f)) + 1f;
        return (1f - tFactor) * fromVal + tFactor * toVal;
    }

    public static float Mix(float a, float b, float t, EaseFunc mix1, EaseFunc mix2, float mixFactor)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        float mix1Val = mix1(a, b, t);
        float mix2Val = mix2(a, b, t);
        return (1f - mixFactor) * mix1Val + mix2Val * mixFactor;
    }

    public static Vector3 Ease(Vector3 a, Vector3 b, float t, EaseFunc ease)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return (b - a) * ease(0, 1, t) + a;
    }

    public static Vector3 CrossFade(Vector3 a, Vector3 b, float t, EaseFunc from, EaseFunc to)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return (b - a) * CrossFade(0, 1, t, from, to) + a;
    }

    public static Vector3 Mix(Vector3 a, Vector3 b, float t, EaseFunc mix1, EaseFunc mix2, float mixFactor)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return (b - a) * Mix(0, 1, t, mix1, mix2, mixFactor) + a;
    }

    public static Quaternion Ease(Quaternion a, Quaternion b, float t, EaseFunc ease)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return Quaternion.LerpUnclamped(a, b, ease(0, 1, t));
    }

    public static Quaternion CrossFade(Quaternion a, Quaternion b, float t, EaseFunc from, EaseFunc to)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return Quaternion.LerpUnclamped(a, b, CrossFade(0, 1, t, from, to));
    }

    public static Quaternion Mix(Quaternion a, Quaternion b, float t, EaseFunc mix1, EaseFunc mix2, float mixFactor)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return Quaternion.LerpUnclamped(a, b, Mix(0, 1, t, mix1, mix2, mixFactor));
    }

    public static Color Ease(Color a, Color b, float t, EaseFunc ease)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        float easeVal = ease(0, 1, t);
        return Color.Lerp(a, b, easeVal);
    }

    public static Color CrossFade(Color a, Color b, float t, EaseFunc from, EaseFunc to)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return Color.Lerp(a, b, CrossFade(0, 1, t, from, to));
    }

    public static Color Mix(Color a, Color b, float t, EaseFunc mix1, EaseFunc mix2, float mixFactor)
    {
        if (t <= 0f) { return a; }
        else if (t >= 1f) { return b; }
        return Color.Lerp(a, b, Mix(0, 1, t, mix1, mix2, mixFactor));
    }

    public static EaseFunc Linear
    {
        get
        {
            return (a, b, t) =>
            {
                return (b - a) * t + a;
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

    public static EaseFunc BounceIn
    {
        get
        {
            return (a, b, t) =>
            {
                return 1f - BounceOut(a, b, (1f - t));
            };
        }
    }

    public static EaseFunc BounceOut
    {
        get
        {
            return (a, b, t) =>
            {
                float val;
                if (t < (1f / 2.75f))
                {
                    val = 7.5625f * t * t;
                }
                else if (t < (2f / 2.75f))
                {
                    val = 7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f;
                }
                else if (t < (2.5f / 2.75f))
                {
                    val = 7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f;
                }
                else
                {
                    val = 7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f;
                }
                return val * (b - a) + a;
            };
        }
    }

    public static EaseFunc BounceInOut
    {
        get
        {
            return (a, b, t) =>
            {
                return CrossFade(a, b, t, BounceIn, BounceOut);
            };
        }
    }

    public static EaseFunc ElasticOut
    {
        get
        {
            return (a, b, t) =>
            {
                float TwoPi = Mathf.PI * 2f;
                float amplitude = 1f;
                float period = 0.3f;
                float s = period / TwoPi * Mathf.Asin(1f / amplitude);
                float val = amplitude * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - s) * TwoPi / period + 1) + 1;
                return (b - a) * val + a;
            };
        }
    }

    public static EaseFunc ElasticIn
    {
        get
        {
            return (a, b, t) =>
            {
                float TwoPi = Mathf.PI * 2f;
                float amplitude = 1f;
                float period = 0.3f;
                float s = period / TwoPi * Mathf.Asin(1f / amplitude);
                float val = amplitude * Mathf.Pow(2f, 10f * (t - 1)) * Mathf.Sin((t - s) * TwoPi / period + 1);
                return (b - a) * val + a;
            };
        }
    }

    public static EaseFunc ElasticInOut
    {
        get
        {
            return (a, b, t) =>
            {
                if (t < 0.5f)
                {
                    t *= 2f;
                    float val = ElasticIn(a, b, t) * 0.5f;
                    return val;
                }
                else
                {
                    t = (t - 0.5f) * 2f;
                    float val = ElasticOut(a, b, t) * 0.5f + 0.5f;
                    return val;
                }
            };
        }
    }
}