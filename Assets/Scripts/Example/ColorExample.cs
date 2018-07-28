using System.Collections;
using EasyEase;
using UnityEngine;
using UnityEngine.UI;

public class ColorExample : MonoBehaviour {
    public Color Begin;
    public Color End;
    public float Duration = 5f;
    public EaseProperty EaseFunc;

    private float _Time;
    Renderer _Rend;

    void Start() {
        _Rend = GetComponentInChildren<Renderer>();
        _Rend.material.shader = Shader.Find("Diffuse");
        _Rend.material.SetColor("_Color", Begin);
        _Time = Duration;
    }

    void Update() {
        _Time += Time.deltaTime;
        if (_Time > Duration) {
            _Time = 0f;
        }
        float normalizedTime = _Time / Duration;
        _Rend.material.SetColor("_Color", Easy.Ease(Begin, End, normalizedTime, EaseFunc));
    }
}