using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
	/// <summary>
	/// Extends <see cref="UnityEditor"/>.<see cref="EditorWindow"/> with quality-of-life methods.
	/// </summary>
	public class BrightEditorWindow : EditorWindow
	{
		#region Draw Int

		/// <summary>
		/// Draws an int field
		/// </summary>
		public static int DrawInt(string label, int value)
			=> BrightEditorUtility.DrawInt(label, value);

		#endregion

		#region Draw Text

		/// <summary>
		/// Draws a text field 
		/// </summary>
		public static string DrawTextField(string label, string text, params GUILayoutOption[] options)
			=> BrightEditorUtility.DrawTextField(label, text, options);

		/// <summary>
		/// Draws a label with bold applied.
		/// </summary>
		protected void DrawBoldLabel(string text, params GUILayoutOption[] options)
			=> BrightEditorUtility.DrawBoldLabel(text, options);

		/// <summary>
		/// Draws a text area with a label.
		/// </summary>
		protected string DrawTextArea(string label, string text, params GUILayoutOption[] options)
			=> BrightEditorUtility.DrawTextArea(text, text, options);

		#endregion

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		protected bool DrawButton(string text, float width = 60, float height = 20)
			=> DrawButton(text, GUILayout.Width(width), GUILayout.Height(height));

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame
		/// </summary>
		protected bool DrawButton(string text, params GUILayoutOption[] options)
			=> BrightEditorUtility.DrawButton(text, options);

		/// <summary>
		/// Draws a button and returns true if it was pressed this frame.
		/// </summary>
		public static bool DrawSimpleButton(string text)
			=> BrightEditorUtility.DrawSimpleButton(text);


		public static void DrawProperty(SerializedObject serializedObject, string propertyName, bool includeChildren = true)
			=> BrightEditorUtility.DrawProperty(serializedObject, propertyName, includeChildren);

		public static void DrawProperty(SerializedProperty property, bool includeChildren = true)
			=> BrightEditorUtility.DrawProperty(property, includeChildren);
		

		public void DrawHelpBox(string message, MessageType messageType = MessageType.None, bool wide = false)
			=> BrightEditorUtility.DrawHelpBox(message, messageType, wide);

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