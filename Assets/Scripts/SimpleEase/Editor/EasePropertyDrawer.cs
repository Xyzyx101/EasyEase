using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EasyEase.EaseProperty))]
public class EasePropertyDrawer : PropertyDrawer {
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		EditorGUI.BeginChangeCheck(); {
			EditorGUI.PropertyField(position, property.FindPropertyRelative("_PropType"), GUIContent.none);
		}
		if (EditorGUI.EndChangeCheck()) {
			var x = property.FindPropertyRelative("Dirty");
			property.FindPropertyRelative("Dirty").boolValue = true;
		}
		EditorGUI.EndProperty();
	}
}