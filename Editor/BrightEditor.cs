using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
	/// <summary>
	/// Derives <see cref="UnityEditor"/>.<see cref="UnityEditor.Editor"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditor : Editor
	{
		#region Draw Text

		/// <summary>
		/// Draws a label with bold applied.
		/// </summary>
		protected void DrawBoldLabel(string text, params GUILayoutOption[] options)
		{
			BrightEditorUtility.DrawBoldLabel(text, options);
		}

		#endregion

		#region Draw Button

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		public bool DrawButton(string text, float width = 60, float height = 20)
			=> BrightEditorUtility.DrawButton(text, width, height);

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		public bool DrawSimpleButton(string text)
			=> BrightEditorUtility.DrawSimpleButton(text);

		#endregion

		#region Draw Property

		protected bool FetchProperty(string propertyName, out SerializedProperty property)
		{
			property = serializedObject.FindProperty(propertyName);
			if (property != null)
			{
				return true;
			}
			Debug.LogWarning($"{propertyName} not found in object {name}");
			return false;
		}

		protected SerializedProperty FetchProperty(string propertyName)
		{
			var property = serializedObject.FindProperty(propertyName);
			if (property != null)
			{
				return property;
			}
			Debug.LogWarning($"{propertyName} not found in object {name}");
			return null;
		}

		protected void DrawProperty(string propertyName)
		{
			SerializedProperty property = FetchProperty(propertyName);
			EditorGUILayout.PropertyField(property, true);
		}

		protected void DrawProperty(SerializedProperty property, bool includeChildren = true)
			=> EditorGUILayout.PropertyField(property, includeChildren);
		

		#endregion

		#region Draw Script Field

		protected void DrawScriptFieldForScriptableObject<T>() where T : ScriptableObject
		{
			BrightEditorUtility.DrawScriptField((T)target);
		}

		protected void DrawScriptFieldForMonoBehaviour<T>() where T : MonoBehaviour
		{
			BrightEditorUtility.DrawScriptField((T)target);
		}

		#endregion


		/// <summary>
		/// Allow fields after this to be seen but not altered via inspector.
		/// </summary>
		public void StartGreyedOutArea(bool toggle = true)
			=> BrightEditorUtility.StartGreyedOutArea(toggle);

		/// <summary>
		/// Allow fields after this to be seen and altered via inspector.
		/// </summary>
		public void EndGreyedOutArea()
			=> BrightEditorUtility.EndGreyedOutArea();

		/// <summary>
		/// Increase the indent level by 1
		/// </summary>
		public void IncreaseIndentLevel()
			=> BrightEditorUtility.IncreaseIndentLevel();


		/// <summary>
		/// Decrease the indent level by 1
		/// </summary>
		public void DecreaseIndentLevel()
			=> BrightEditorUtility.DecreaseIndentLevel();

		/// <summary>
		/// Set the indent level back to 0
		/// </summary>
		public void ResetIndentLevel()
			=> BrightEditorUtility.ResetIndentLevel();

	}
}