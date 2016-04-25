using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VectorExample : MonoBehaviour
{

    public enum EaseFunction
    {
        Linear,
        EaseIn,
        EaseInCubic,
        EaseInQuartic,
        EaseInQuintic,
        EaseOut,
        EaseOutCubic,
        EaseOutQuartic,
        EaseOutQuintic,
        EaseInOut,
        EaseInOutCubic,
        EaseInOutQuartic,
        EaseInOutQuintic,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInExp,
        EaseOutExp,
        EaseInOutExp,
        EaseInOvershoot,
        EaseOutOvershoot,
        EaseInOutOvershoot
    }

    public float Distance = 5f;
    public float Duration = 5f;
    public EaseFunction EaseFunc;

    private float _Time;
    private Vector3 _Begin;
    private Vector3 _End;

    void Start()
    {
        _Begin = transform.position;
        _End = transform.position + Vector3.forward * Distance;
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
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Linear);
                break;
            case EaseFunction.EaseIn:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseIn);
                break;
            case EaseFunction.EaseOut:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOut);
                break;
            case EaseFunction.EaseInOut:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOut);
                break;
            case EaseFunction.EaseInCubic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInCubic);
                break;
            case EaseFunction.EaseInQuartic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInQuartic);
                break;
            case EaseFunction.EaseInQuintic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInQuintic);
                break;
            case EaseFunction.EaseOutCubic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutCubic);
                break;
            case EaseFunction.EaseOutQuartic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutQuartic);
                break;
            case EaseFunction.EaseOutQuintic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutQuintic);
                break;

            case EaseFunction.EaseInOutCubic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutCubic);
                break;
            case EaseFunction.EaseInOutQuartic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutQuartic);
                break;
            case EaseFunction.EaseInOutQuintic:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutQuintic);
                break;
            case EaseFunction.EaseInSine:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInSine);
                break;
            case EaseFunction.EaseOutSine:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutSine);
                break;
            case EaseFunction.EaseInOutSine:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutSine);
                break;
            case EaseFunction.EaseInExp:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInExp);
                break;
            case EaseFunction.EaseOutExp:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutExp);
                break;
            case EaseFunction.EaseInOutExp:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutExp);
                break;
            case EaseFunction.EaseInOvershoot:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOvershoot);
                break;
            case EaseFunction.EaseOutOvershoot:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutOvershoot);
                break;
            case EaseFunction.EaseInOutOvershoot:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutOvershoot);
                break;
        }
    }
}
