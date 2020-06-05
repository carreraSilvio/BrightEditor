using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
	/// <summary>
	/// Extends <see cref="UnityEditor"/>.<see cref="EditorWindow"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditorWindow : EditorWindow
	{
		/// <summary>
		/// Draws a label with bold applied.
		/// </summary>
		protected void DrawBoldLabel(string text, params GUILayoutOption[] options)
		{
			BrightEditorUtility.DrawBoldLabel(text, options);
		}

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		protected bool DrawButton(string text, float width = 60, float height = 20)
		{
			return DrawButton(text, GUILayout.Width(width), GUILayout.Height(height));
		}

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		protected bool DrawButton(string text, params GUILayoutOption[] options)
		{
			return BrightEditorUtility.DrawButton(text, options);
		}

		/// <summary>
		/// Draws a text area with a label.
		/// </summary>
		public string DrawTextArea(string label, string text, params GUILayoutOption[] options)
		{
			return BrightEditorUtility.DrawTextArea(label, text, options);
		}

		/// <summary>
		/// Allow fields after this to be seen but not altered via inspector.
		/// </summary>
		public void StartGreyedOutArea(bool toggle = true)
		{
			BrightEditorUtility.StartGreyedOutArea(toggle);
		}

		/// <summary>
		/// Allow fields after this to be seen and altered via inspector.
		/// </summary>
		public void EndGreyedOutArea()
		{
			BrightEditorUtility.EndGreyedOutArea();
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