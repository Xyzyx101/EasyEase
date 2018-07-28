using System.Collections;
using EasyEase;
using UnityEngine;
using UnityEngine.UI;

public class FloatExample : MonoBehaviour {
    public float Begin = 0f;
    public float End = 1f;
    public float Duration = 5f;
    public float _CurrentValue;
    public EaseProperty EaseFunc;

    private float _Time;

    void Start() {
        _CurrentValue = Begin;
        _Time = Duration;
    }

    void Update() {
        _Time += Time.deltaTime;
        if (_Time > Duration) {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        _CurrentValue = Easy.Ease(Begin, End, normalizedTime, EaseFunc);
    }
}