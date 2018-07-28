using System.Collections;
using System.Collections.Generic;
using EasyEase;
using UnityEngine;

public class PositionOverTime : MonoBehaviour {

	[SerializeField]
	private Transform MoveTo;
	[SerializeField]
	private GameObject MyObject;
	[SerializeField]
	private float TimeToMove = 3.0f;
	[SerializeField]
	private EaseProperty EaseFunction = EaseType.Linear;

	private float StartTime;
	private Vector3 StartPosition;
	bool Moving;

	private void Start() {
		Go();
	}

	private void Update() {
		if (Moving) {
			MyObject.transform.position = Easy.Ease(StartPosition, MoveTo.position, StartTime, TimeToMove, EaseFunction);
			if (Time.time > StartTime + TimeToMove) {
				Moving = false;
			}
		}
	}

	public void Go() {
		StartTime = Time.time;
		StartPosition = MyObject.transform.position;
		Moving = true;
	}
}