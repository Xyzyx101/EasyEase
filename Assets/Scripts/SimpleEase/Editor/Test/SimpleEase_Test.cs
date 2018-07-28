using System.Collections;
using System.Collections.Generic;
using EasyEase;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SimpleEase_Test {
	static List<EaseProperty> GetAllEaseTypes() {
		var allTypes = new List<EaseProperty>();
		foreach (var t in (EaseType[]) EaseType.GetValues(typeof(EaseType))) {
			allTypes.Add(new EaseProperty() { PropType = t });
		}
		return allTypes;
	}

	struct TestData {
		public float Start;
		public float End;
	}

	static TestData[] TestValues = new TestData[] {
		new TestData() { Start = 0.0f, End = 1.0f },
			new TestData() { Start = 0.0f, End = 123456789.0f },
			new TestData() { Start = -1.0f, End = 1.0f },
			new TestData() { Start = -343500.0f, End = 4354570.0f },
	};

	[Test]
	public void AllEaseTypesReturnFloatValues() {
		foreach (var easeType in GetAllEaseTypes()) {
			foreach (var test in TestValues) {
				float value = Easy.Ease(test.Start, test.End, 0.5f, easeType);
				// value can never be null but This still verifies that every possible input returns a value without an exception.
				Assert.IsNotNull(value, easeType.PropType.ToString() + " failed for values between " + test.Start + " and " + test.End);
			}
		}
	}

	[Test]
	public void AllEaseTypesReturnVectorValues() {
		foreach (var easeType in GetAllEaseTypes()) {
			Vector3 value = Easy.Ease(Vector3.up, Vector3.right, 0.5f, easeType);
			Assert.IsNotNull(value, easeType.PropType.ToString() + " failed for Vector3");
		}
	}

	[Test]
	public void AllEaseTypesReturnColorValues() {
		foreach (var easeType in GetAllEaseTypes()) {
			Color value = Easy.Ease(Color.green, Color.red, 0.5f, easeType);
			Assert.IsNotNull(value, easeType.PropType.ToString() + " failed for Color");
		}
	}

	[Test]
	public void AllEaseTypesReturnQuaternionValues() {
		foreach (var easeType in GetAllEaseTypes()) {
			var start = Quaternion.AngleAxis(90.0f, Vector3.up);
			var end = Quaternion.AngleAxis(45.0f, Vector3.right);
			Quaternion value = Easy.Ease(start, end, 0.5f, easeType);
			Assert.IsNotNull(value, easeType.PropType.ToString() + " failed for Quaternion");
		}
	}

	[Test]
	public void AllEaseTypesStartAtTheBeginning() {
		foreach (var easeType in GetAllEaseTypes()) {
			foreach (var test in TestValues) {
				float value = Easy.Ease(test.Start, test.End, 0.0f, easeType);
				Assert.IsTrue(EqualOrCloseEnough(value, test.Start), easeType.PropType.ToString() + " failed for t = 0.0f");

				value = Easy.Ease(test.Start, test.End, 0.01f, easeType);
				float startDelta = Mathf.Abs(value - test.Start);
				float endDelta = Mathf.Abs(test.End - value);
				Assert.Less(startDelta, endDelta, easeType.PropType.ToString() + " failed. startDelta is " + startDelta + " and endDelta is " + endDelta);
			}
		}
	}

	[Test]
	public void AllEaseTypesEndAtTheEnd() {
		foreach (var easeType in GetAllEaseTypes()) {
			foreach (var test in TestValues) {
				float value = Easy.Ease(test.Start, test.End, 1.0f, easeType);
				Assert.IsTrue(EqualOrCloseEnough(value, test.End), easeType.PropType.ToString() + " failed for t = 1.0f");

				value = Easy.Ease(test.Start, test.End, 0.99f, easeType);
				float startDelta = Mathf.Abs(value - test.Start);
				float endDelta = Mathf.Abs(test.End - value);
				Assert.Greater(startDelta, endDelta, easeType.PropType.ToString() + " failed. startDelta is " + startDelta + " and endDelta is " + endDelta);
			}
		}
	}

	static bool EqualOrCloseEnough(float a, float b) {
		return Mathf.Abs(a - b) < float.Epsilon;
	}
}