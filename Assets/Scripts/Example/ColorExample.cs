using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorExample : MonoBehaviour
{

    public enum EaseFunction
    {
        Linear,
        SmoothStart2,
        SmoothStop2,
        ExpStartStop
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
            case EaseFunction.SmoothStart2:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.SmoothStart2));
                break;
            case EaseFunction.SmoothStop2:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.SmoothStop2));
                break;
            case EaseFunction.ExpStartStop:
                _Rend.material.SetColor("_Color", SimpleEase.Ease(Begin, End, normalizedTime, SimpleEase.ExpStartStop));
                break;
        }
    }
}
