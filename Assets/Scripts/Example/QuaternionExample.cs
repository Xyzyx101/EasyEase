using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuaternionExample : MonoBehaviour
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

    public float Duration = 5f;
    public EaseFunction EaseFunc;

    private float _Time;
    private Quaternion _Begin;
    private Quaternion _End;

    void Start()
    {
        _Begin = transform.rotation;
        _End = Quaternion.LookRotation(-transform.forward, Vector3.up);
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
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Linear);
                break;
            case EaseFunction.EaseIn:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseIn);
                break;
            case EaseFunction.EaseOut:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOut);
                break;
            case EaseFunction.EaseInOut:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOut);
                break;
            case EaseFunction.EaseInCubic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInCubic);
                break;
            case EaseFunction.EaseInQuartic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInQuartic);
                break;
            case EaseFunction.EaseInQuintic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInQuintic);
                break;
            case EaseFunction.EaseOutCubic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutCubic);
                break;
            case EaseFunction.EaseOutQuartic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutQuartic);
                break;
            case EaseFunction.EaseOutQuintic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutQuintic);
                break;
            case EaseFunction.EaseInOutCubic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutCubic);
                break;
            case EaseFunction.EaseInOutQuartic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutQuartic);
                break;
            case EaseFunction.EaseInOutQuintic:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutQuintic);
                break;
            case EaseFunction.EaseInSine:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInSine);
                break;
            case EaseFunction.EaseOutSine:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutSine);
                break;
            case EaseFunction.EaseInOutSine:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutSine);
                break;
            case EaseFunction.EaseInExp:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInExp);
                break;
            case EaseFunction.EaseOutExp:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutExp);
                break;
            case EaseFunction.EaseInOutExp:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutExp);
                break;
            case EaseFunction.EaseInOvershoot:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOvershoot);
                break;
            case EaseFunction.EaseOutOvershoot:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseOutOvershoot);
                break;
            case EaseFunction.EaseInOutOvershoot:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.EaseInOutOvershoot);
                break;
        }
    }
}
