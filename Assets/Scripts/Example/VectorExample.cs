using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VectorExample : MonoBehaviour
{

    public enum EaseFunction
    {
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
        Windup,
        Windup2,
        Windup3,
        Overshoot,
        Overshoot2,
        Overshoot3,
        ElasticStart,
        ElasticStart2,
        ElasticStart3,
        ElasticStop,
        ElasticStop2,
        ElasticStop3,
        BounceStart,
        BounceStart2,
        BounceStart3,
        BounceStop,
        BounceStop2,
        BounceStop3
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
        if( _Time > Duration ) {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        switch( EaseFunc ) {
            case EaseFunction.Linear:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Linear);
                break;
            case EaseFunction.SmoothStart2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStart2);
                break;
            case EaseFunction.SmoothStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStop2);
                break;
            case EaseFunction.SmoothStartStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStartStop2);
                break;
            case EaseFunction.SmoothStart3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStart3);
                break;
            case EaseFunction.SmoothStart4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStart4);
                break;
            case EaseFunction.SmoothStart5:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStart5);
                break;
            case EaseFunction.SmoothStop3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStop3);
                break;
            case EaseFunction.SmoothStop4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStop4);
                break;
            case EaseFunction.SmoothStop5:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStop5);
                break;
            case EaseFunction.SmoothStartStop3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStartStop3);
                break;
            case EaseFunction.SmoothStartStop4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStartStop4);
                break;
            case EaseFunction.SmoothStartStop5:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.SmoothStartStop5);
                break;
            case EaseFunction.ExpStart:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStart);
                break;
            case EaseFunction.ExpStart2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStart2);
                break;
            case EaseFunction.ExpStart4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStart4);
                break;
            case EaseFunction.ExpStop:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStop);
                break;
            case EaseFunction.ExpStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStop2);
                break;
            case EaseFunction.ExpStop4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStop4);
                break;
            case EaseFunction.ExpStartStop:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStartStop);
                break;
            case EaseFunction.ExpStartStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStartStop2);
                break;
            case EaseFunction.ExpStartStop4:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ExpStartStop4);
                break;
            case EaseFunction.Windup:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Windup);
                break;
            case EaseFunction.Windup2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Windup2);
                break;
            case EaseFunction.Windup3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.Windup3);
                break;
            case EaseFunction.Overshoot:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.OverShoot);
                break;
            case EaseFunction.Overshoot2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.OverShoot2);
                break;
            case EaseFunction.Overshoot3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.OverShoot3);
                break;
            case EaseFunction.ElasticStart:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStart);
                break;
            case EaseFunction.ElasticStart2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStart2);
                break;
            case EaseFunction.ElasticStart3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStart3);
                break;
            case EaseFunction.ElasticStop:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStop);
                break;
            case EaseFunction.ElasticStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStop2);
                break;
            case EaseFunction.ElasticStop3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.ElasticStop3);
                break;
            case EaseFunction.BounceStart:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStart);
                break;
            case EaseFunction.BounceStart2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStart2);
                break;
            case EaseFunction.BounceStart3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStart3);
                break;
            case EaseFunction.BounceStop:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStop);
                break;
            case EaseFunction.BounceStop2:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStop2);
                break;
            case EaseFunction.BounceStop3:
                transform.position = SimpleEase.Ease(_Begin, _End, normalizedTime, SimpleEase.BounceStop3);
                break;
        }
    }
}
