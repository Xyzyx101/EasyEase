using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatExample : MonoBehaviour
{

    public enum EaseFunction
    {
        Linear,
        EaseIn,
        EaseOut,
        EaseInOut
    }

    public float Begin = 0f;
    public float End = 1f;
    public float Duration = 5f;
    public float _CurrentValue;
    public EaseFunction EaseFunc;

    private float _Time;

    void Start()
    {
        _CurrentValue = Begin;
        _Time = Duration;
    }

    void Update()
    {
        _Time += Time.deltaTime;
        if (_Time > Duration)
        {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        switch (EaseFunc)
        {
            case EaseFunction.Linear:
                _CurrentValue = SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.Linear);
                break;
            case EaseFunction.EaseIn:
                _CurrentValue = SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseIn);
                break;
            case EaseFunction.EaseOut:
                _CurrentValue = SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOut);
                break;
            case EaseFunction.EaseInOut:
                _CurrentValue = SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOut);
                break;

        }
    }
}
