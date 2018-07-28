using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpeedTest))]
public class SpeedTestEditor : Editor {
	private string Result;
	private void OnEnable() {
		Result = string.Empty;
	}
	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		var speedTest = target as SpeedTest;
		if (GUILayout.Button("Run Test")) {
			speedTest.RunTest();
			Result = speedTest.Iterations.ToString() + " Iterations in " + speedTest.CompleteTime.ToString() + "ms";
		}
		GUILayout.TextField(Result);
	}
}