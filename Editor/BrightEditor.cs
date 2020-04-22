using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// Derives <see cref="UnityEditor"/>.<see cref="UnityEditor.Editor"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditor : UnityEditor.Editor
    {
		protected void DrawBoldLabel(string text)
		{
			GUILayout.Label(text, EditorStyles.boldLabel);
		}

		protected bool DrawButton(string text, float width = 60, float height = 20)
		{
			return GUILayout.Button(text, GUILayout.Width(width), GUILayout.Height(height));
		}

		protected void DrawProperty(string name)
		{
			SerializedProperty property = serializedObject.FindProperty(name);
			EditorGUILayout.PropertyField(property, true);
		}

		protected void DrawScriptFieldForScriptableObject<T>() where T : ScriptableObject
		{
			BrightEditorUtility.DrawScriptField((T)target);
		}

		protected void DrawScriptFieldForMonoBehaviour<T>() where T : MonoBehaviour
		{
			BrightEditorUtility.DrawScriptField((T)target);
		}

		/// <summary>
		/// Increase the indent level by 1
		/// </summary>
		public void IncreaseIndentLevel()
		{
			BrightEditorUtility.IncreaseIndentLevel();
		}

		/// <summary>
		/// Decrease the indent level by 1
		/// </summary>
		public void DecreaseIndentLevel()
		{
			BrightEditorUtility.DecreaseIndentLevel();
		}

		/// <summary>
		/// Set the indent level back to 0
		/// </summary>
		public void ResetIndentLevel()
		{
			BrightEditorUtility.ResetIndentLevel();
		}

		protected SerializedProperty FetchProperty(string propertyName)
		{
			var property = serializedObject.FindProperty(propertyName);
			if (property == null) Debug.LogWarning($"{propertyName} not found in object {name}");

			return property;
		}
	}
}