using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PositionOverTime))]
public class PositionOverTimeEditor : Editor {
	private string Result;
	private void OnEnable() {
		Result = string.Empty;
	}
	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		var posOverTime = target as PositionOverTime;
		if (GUILayout.Button("Go")) {
			posOverTime.Go();
		}
	}
}