using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// Collection of methods that wraps <see cref="GUI"/>, <see cref="GUILayout"/>, <see cref="UnityEditor.EditorGUI"/> and <see cref="UnityEditor.EditorGUILayout"/> methods. 
	/// </summary>
	public static class BrightEditorUtility
	{
		#region Draw Text

		/// <summary>
		/// Draws a label with bold applied.
		/// </summary>
		public static void DrawBoldLabel(string text, params GUILayoutOption[] options)
		{
			EditorGUILayout.LabelField(text, EditorStyles.boldLabel, options);
		}

		/// <summary>
		/// Draws a text area with a label.
		/// </summary>
		public static string DrawTextArea(string label, string text, params GUILayoutOption[] options)
		{
			EditorGUILayout.LabelField(label);
			return EditorGUILayout.TextArea(text, options);
		}

		#endregion

		#region Draw Button

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		public static bool DrawButton(string text, float width = 60, float height = 20)
		{
			return GUILayout.Button(text, GUILayout.Width(width), GUILayout.Height(height));
		}

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		public static bool DrawButton(string text, params GUILayoutOption[] options)
		{
			return GUILayout.Button(text, options);
		}

		/// <summary>
		/// Draws a button with a prefix label on the same line
		/// </summary>
		public static bool DrawInlineButton(string prefixLabelText, string buttonText)
		{
			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.PrefixLabel(prefixLabelText);
			var result = GUILayout.Button(buttonText);

			EditorGUILayout.EndHorizontal();

			return result;
		}

		#endregion

		#region Draw Property

		public static void DrawProperty(SerializedObject serializedObject, string propertyName)
		{
			SerializedProperty property = serializedObject.FindProperty(propertyName);
			EditorGUILayout.PropertyField(property, true);
		}

		public static void DrawProperty(SerializedProperty property)
		{
			EditorGUILayout.PropertyField(property, true);
		}

		#endregion

		/// <summary>
		/// Allow fields after this to be seen but not altered via inspector.
		/// </summary>
		public static void StartGreyedOutArea(bool toggle = true)
		{
			GUI.enabled = toggle;
		}

		/// <summary>
		/// Allow fields after this to be seen and altered via inspector.
		/// </summary>
		public static void EndGreyedOutArea()
		{
			GUI.enabled = true;
		}

		/// <summary>
		/// Increase the indent level by 1
		/// </summary>
		public static void IncreaseIndentLevel()
		{
			EditorGUI.indentLevel++;
		}

		/// <summary>
		/// Decrease the indent level by 1
		/// </summary>
		public static void DecreaseIndentLevel()
		{
			EditorGUI.indentLevel++;
		}

		/// <summary>
		/// Set the indent level back to 0
		/// </summary>
		public static void ResetIndentLevel()
		{
			EditorGUI.indentLevel = 0;
		}

		public static void DrawScriptField(MonoBehaviour target)
		{
			GUI.enabled = false;
			EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(target), target.GetType(), false);
			GUI.enabled = true;
		}

		public static void DrawScriptField(ScriptableObject target)
		{
			GUI.enabled = false;
			EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject(target), target.GetType(), false);
			GUI.enabled = true;
		}
	}

}