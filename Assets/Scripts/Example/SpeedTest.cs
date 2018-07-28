using System.Collections;
using System.Collections.Generic;
using SimpleEase;
using UnityEngine;

public class SpeedTest : MonoBehaviour {

	[SerializeField]
	private EaseProperty EaseProp = EaseType.Linear;
	[SerializeField]
	private float Start = 0.0f;
	[SerializeField]
	private float End = 999.0f;

	[SerializeField]
	private int _Iterations = 100000;
	public int Iterations {
		get {
			return _Iterations;
		}
	}
	public float CompleteTime {
		get {
			return _CompleteTime;
		}
	}
	private float _CompleteTime;

	public void RunTest() {
		var watch = System.Diagnostics.Stopwatch.StartNew();
		float val = Start;
		float t = 0.0f;
		float interval = (End - Start) / (float) Iterations;
		for (int i = 0; i < _Iterations; ++i) {
			t += interval;
			val = SimpleEase.Easing.Ease(Start, End, t, EaseProp);
		}
		_CompleteTime = watch.ElapsedMilliseconds;
		Debug.Log(_Iterations + " iterations in " + _CompleteTime + "ms");
		watch.Stop();
	}
}