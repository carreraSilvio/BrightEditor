using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// Derives <see cref="UnityEditor"/>.<see cref="UnityEditor.Editor"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditor : UnityEditor.Editor
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
		{
			return BrightEditorUtility.DrawButton(text, width, height);
		}

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		public bool DrawButton(string text, params GUILayoutOption[] options)
		{
			return BrightEditorUtility.DrawButton(text, options);
		}

		#endregion

		#region Draw Property

		protected SerializedProperty FetchProperty(string propertyName)
		{
			var property = serializedObject.FindProperty(propertyName);
			if (property == null) Debug.LogWarning($"{propertyName} not found in object {name}");

			return property;
		}

		protected void DrawProperty(string name)
		{
			SerializedProperty property = serializedObject.FindProperty(name);
			EditorGUILayout.PropertyField(property, true);
		}

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
		{
			GUI.enabled = toggle;
		}

		/// <summary>
		/// Allow fields after this to be seen and altered via inspector.
		/// </summary>
		public void EndGreyedOutArea()
		{
			GUI.enabled = true;
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
	}
}