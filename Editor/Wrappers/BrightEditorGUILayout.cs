using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	public static class BrightEditorGUILayout
	{
		public static void DrawBoldLabelField(string text)
		{
			EditorGUILayout.LabelField(text, EditorStyles.boldLabel);
		}

		public static void DrawProperty(SerializedObject serializedObject, string propertyName)
		{
			SerializedProperty property = serializedObject.FindProperty(propertyName);
			EditorGUILayout.PropertyField(property, true);
		}

		public static void DrawProperty(SerializedProperty property)
		{
			EditorGUILayout.PropertyField(property, true);
		}

		public static bool DrawInlineButton(string prefixLabelText, string buttonText)
		{
			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(prefixLabelText);
			var result = GUILayout.Button(buttonText);

			EditorGUILayout.EndHorizontal();

			return result;
		}
	}
}