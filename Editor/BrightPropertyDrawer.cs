using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditor.Core
{
	public class BrightPropertyDrawer : UnityEditor.PropertyDrawer
	{

		public float SingleLineHeight
			=> EditorGUIUtility.singleLineHeight;


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
		/// Increase indent level by 1
		/// </summary>
		public void IncreaseIndentLevel()
			=> BrightEditorUtility.IncreaseIndentLevel();


		/// <summary>
		/// Decrease indent level by 1
		/// </summary>
		public void DecreaseIndentLevel()
			=> BrightEditorUtility.DecreaseIndentLevel();


		/// <summary>
		/// Set indent level back to 0
		/// </summary>
		public void ResetIndentLevel()
			=> BrightEditorUtility.ResetIndentLevel();

		public void DrawProperty(ref Rect baseRect, SerializedProperty property, string propertyRelative, float increaseX = 0f, float increaseY = 0)
		{
			baseRect.x += increaseX;
			baseRect.y += increaseY;
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

			EditorGUI.PropertyField(rect, property.FindPropertyRelative(propertyRelative));
		}

		public void DrawProperty(ref Rect baseRect, SerializedProperty property, float increaseX = 0f, float increaseY = 0)
		{
			baseRect.x += increaseX;
			baseRect.y += increaseY;
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

			EditorGUI.PropertyField(rect, property);
		}

	}
}

