using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EasyEase.EaseProperty))]
public class EasePropertyDrawer : PropertyDrawer {
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		EditorGUI.PropertyField(position, property.FindPropertyRelative("PropType"), GUIContent.none);
		EditorGUI.EndProperty();
	}
}