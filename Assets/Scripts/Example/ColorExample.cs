using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorExample : MonoBehaviour
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

    public Color Begin;
    public Color End;
    public float Duration = 5f;
    public EaseFunction EaseFunc;

    private float _Time;
    Renderer _Rend;


    void Start()
    {
        _Rend = GetComponentInChildren<Renderer>();
        _Rend.material.shader = Shader.Find("Diffuse");
        _Rend.material.SetColor("_Color", Begin);
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
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.Linear));
                break;
            case EaseFunction.EaseIn:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseIn));
                break;
            case EaseFunction.EaseOut:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOut));
                break;
            case EaseFunction.EaseInOut:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOut));
                break;
            case EaseFunction.EaseInCubic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInCubic));
                break;
            case EaseFunction.EaseInQuartic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInQuartic));
                break;
            case EaseFunction.EaseInQuintic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInQuintic));
                break;
            case EaseFunction.EaseOutCubic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutCubic));
                break;
            case EaseFunction.EaseOutQuartic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutQuartic));
                break;
            case EaseFunction.EaseOutQuintic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutQuintic));
                break;
            case EaseFunction.EaseInOutCubic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutCubic));
                break;
            case EaseFunction.EaseInOutQuartic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutQuartic));
                break;
            case EaseFunction.EaseInOutQuintic:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutQuintic));
                break;
            case EaseFunction.EaseInSine:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInSine));
                break;
            case EaseFunction.EaseOutSine:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutSine));
                break;
            case EaseFunction.EaseInOutSine:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutSine));
                break;
            case EaseFunction.EaseInExp:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInExp));
                break;
            case EaseFunction.EaseOutExp:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutExp));
                break;
            case EaseFunction.EaseInOutExp:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutExp));
                break;
            case EaseFunction.EaseInOvershoot:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOvershoot));
                break;
            case EaseFunction.EaseOutOvershoot:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseOutOvershoot));
                break;
            case EaseFunction.EaseInOutOvershoot:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.EaseInOutOvershoot));
                break;
        }
    }
}
