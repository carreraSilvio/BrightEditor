using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// A wrapper for <see cref="UnityEditor"/>.<see cref="UnityEditor.EditorWindow"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditorWindow : EditorWindow 
	{
		/// <summary>
		/// Draws a label with bold applied.
		/// </summary>
		public void DrawBoldLabel(string text)
		{
			BrightEditorUtility.DrawBoldLabel(text);
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