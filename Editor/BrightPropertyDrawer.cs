using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
	/// <summary>
	/// Extends <see cref="UnityEditor"/>.<see cref="PropertyDrawer"/> with quality-of-life methods.
	/// </summary>
	public class BrightPropertyDrawer : PropertyDrawer
	{
		public float SingleLineHeight => EditorGUIUtility.singleLineHeight;

		/// <summary>
		/// Allow fields after this to be seen but not altered via inspector.
		/// </summary>
		public void StartGreyedOutArea(bool toggle = true) => BrightEditorUtility.StartGreyedOutArea(toggle);

		/// <summary>
		/// Allow fields after this to be seen and altered via inspector.
		/// </summary>
		public void EndGreyedOutArea() => BrightEditorUtility.EndGreyedOutArea();

		/// <summary>
		/// Increase indent level by 1
		/// </summary>
		public void IncreaseIndentLevel() => BrightEditorUtility.IncreaseIndentLevel();

		/// <summary>
		/// Decrease indent level by 1
		/// </summary>
		public void DecreaseIndentLevel() => BrightEditorUtility.DecreaseIndentLevel();

		/// <summary>
		/// Set indent level back to 0
		/// </summary>
		public void ResetIndentLevel() => BrightEditorUtility.ResetIndentLevel();

		public void SetLabelWidth(float labelWidth) => BrightEditorUtility.SetLabelWidth(labelWidth);

		/// <summary>
		/// Set default label width back to the default value. See <see cref="EditorGUIUtility.labelWidth"/>
		/// </summary>
		public  void ResetLabelWidth() => SetLabelWidth(0f);


		public void DrawLabel(ref Rect baseRect, string label = "label", string label2 = "label2", float increaseX = 0f, float increaseY = 0)
		{
			baseRect.x += increaseX;
			baseRect.y += increaseY;
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);
			EditorGUI.LabelField(rect, label, label2);
		}

		public void DrawProperty(Rect baseRect, SerializedProperty property, string propertyRelativeName, float increaseX = 0f, float increaseY = 0)
			 => DrawProperty(ref baseRect, property, propertyRelativeName, increaseX, increaseY);

		public void DrawProperty(ref Rect baseRect, SerializedProperty property, string propertyRelativeName, float increaseX = 0f, float increaseY = 0, float labelWidth = 0)
		{
			if (FetchPropertyRelative(property, propertyRelativeName, out SerializedProperty propertyRelative))
			{
				baseRect.x += increaseX;
				baseRect.y += increaseY;
				Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

				SetLabelWidth(labelWidth);
				EditorGUI.PropertyField(rect, propertyRelative, true);
				ResetLabelWidth();
			}
		}

		public void DrawProperty(ref Rect baseRect, SerializedProperty property, float increaseX = 0f, float increaseY = 0)
		{
			baseRect.x += increaseX;
			baseRect.y += increaseY;
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

			EditorGUI.PropertyField(rect, property);
		}

		public void DrawPropertyWithNoLabel(ref Rect baseRect, SerializedProperty property, string propertyRelativeName, float offsetRectX = 0f, float offsetRectY = 0, float widthPercent = 1)
		{
			if (FetchPropertyRelative(property, propertyRelativeName, out SerializedProperty propertyRelative))
			{
				DrawPropertyWithNoLabel(ref baseRect, propertyRelative, offsetRectX, offsetRectY, widthPercent);
			}
		}


		public void DrawPropertyWithNoLabel(Rect baseRect, SerializedProperty property, string propertyRelativeName)
		{
			if (FetchPropertyRelative(property, propertyRelativeName, out SerializedProperty propertyRelative))
			{
				DrawPropertyWithNoLabel(baseRect, propertyRelative);
			}
		}

		public void DrawPropertyWithNoLabel(Rect baseRect, SerializedProperty property, float offsetRectX = 0f, float offsetRectY = 0, float widthPercent = 1)
			=> DrawPropertyWithNoLabel(ref baseRect, property, offsetRectX, offsetRectY, widthPercent);

		public void DrawPropertyWithNoLabel(ref Rect baseRect, SerializedProperty property, float offsetRectX = 0f, float offsetRectY = 0, float widthPercent = 1)
		{
			baseRect.x += offsetRectX;
			baseRect.y += offsetRectY;
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width * widthPercent, SingleLineHeight);

			DrawPropertyWithNoLabel(rect, property);
		}

		public void DrawPropertyWithNoLabel(Rect baseRect, SerializedProperty property)
		{
			Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

			EditorGUI.PropertyField(rect, property, GUIContent.none);
		}



		protected bool FetchPropertyRelative(SerializedProperty property, string propertyRelativeName, out SerializedProperty propertyRelative)
		{
			propertyRelative = property.FindPropertyRelative(propertyRelativeName);
			if (propertyRelative != null)
			{
				return true;
			}
			Debug.LogWarning($"{propertyRelativeName} not found in object {property.displayName}");
			return false;
		}

		protected SerializedProperty FetchPropertyRelative(SerializedProperty property, string propertyRelativeName) => property.FindPropertyRelative(propertyRelativeName);
	
	}
}

