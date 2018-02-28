using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuaternionExample : MonoBehaviour
{

    public enum EaseFunction
    {
        Linear,
        SmoothStart2,
        SmoothStop2,
        ExpStartStop
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
            case EaseFunction.SmoothStart2:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStart2);
                break;
            case EaseFunction.SmoothStop2:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStop2);
                break;
            case EaseFunction.ExpStartStop:
                transform.rotation = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStartStop2);
                break;
        }
    }
}
