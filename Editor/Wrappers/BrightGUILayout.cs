using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	public static class BrightGUILayout
	{
		public static void DrawBoldLabel(string text)
		{
			GUILayout.Label(text, EditorStyles.boldLabel);
		}

		public static bool DrawToggle(bool boolean, string text, float width = 60, float height = 20)
		{
			return GUILayout.Toggle(boolean, text, GUILayout.MinWidth(width), GUILayout.MinHeight(height));
		}

		public static bool DrawButton(string text, float width = 60, float height = 20)
		{
			return DrawButton(text, GUILayout.Width(width), GUILayout.Height(height));
		}

		public static bool DrawButton(string text, params GUILayoutOption[] options)
		{
			return GUILayout.Button(text, options);
		}
		
	}
}