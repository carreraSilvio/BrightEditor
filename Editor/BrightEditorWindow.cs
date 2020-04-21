using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// A <see cref="UnityEditor"/>.<see cref="UnityEditor.EditorWindow"/> wrapper with quality-of-life methods.
	/// </summary>
	public class BrightEditorWindow : EditorWindow 
	{
		public void LabelBold(string text)
		{
			BrightEditorUtility.DrawLabelBold(text);
		}

		public void StartGreyedOutArea(bool toggle = true)
		{
			BrightEditorUtility.StartGreyedOutArea(toggle);
		}

		public void EndGreyedOutArea()
		{
			BrightEditorUtility.EndGreyedOutArea();
		}

		public void IncreaseIndentLevel()
		{
			BrightEditorUtility.IncreaseIndentLevel();
		}

		public void DecreaseIndentLevel()
		{
			BrightEditorUtility.DecreaseIndentLevel();
		}

		public void ResetIndentLevel()
		{
			BrightEditorUtility.ResetIndentLevel();
		}

		//private int test;

		//public int Test { get => test; set => test = value; }
	}

}