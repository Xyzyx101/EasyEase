using System.Collections;
using EasyEase;
using UnityEngine;
using UnityEngine.UI;

public class VectorExample : MonoBehaviour {
    public float Distance = 5f;
    public float Duration = 5f;
    public EaseProperty EaseFunc;

    private float _Time;
    private Vector3 _Begin;
    private Vector3 _End;

    void Start() {
        _Begin = transform.position;
        _End = transform.position + Vector3.forward * Distance;
        _Time = Duration;
    }

    void Update() {
        _Time += Time.deltaTime;
        if (_Time > Duration) {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        transform.position = Easy.Ease(_Begin, _End, normalizedTime, EaseFunc);
    }
}