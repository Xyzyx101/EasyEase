using System.Collections;
using SimpleEase;
using UnityEngine;
using UnityEngine.UI;

public class QuaternionExample : MonoBehaviour {
    public float Duration = 5f;
    public EaseProperty EaseFunc;

    private float _Time;
    private Quaternion _Begin;
    private Quaternion _End;

    void Start() {
        _Begin = transform.rotation;
        _End = Quaternion.LookRotation(-transform.forward, Vector3.up);
        _Time = Duration;
    }

    void Update() {
        _Time += Time.deltaTime;
        if (_Time > Duration) {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        transform.rotation = Easing.Ease(_Begin, _End, normalizedTime, EaseFunc);
    }
}