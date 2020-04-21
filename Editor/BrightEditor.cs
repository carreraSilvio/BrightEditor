using UnityEditor;

namespace BrightLib.BrightEditor.Core
{
	/// <summary>
	/// A <see cref="UnityEditor"/>.<see cref="UnityEditor.Editor"/> wrapper with quality-of-life methods.
	/// </summary>
	public class BrightEditor : UnityEditor.Editor
    {
		public void DrawProperty(string propertyName)
		{
			SerializedProperty property = serializedObject.FindProperty(propertyName);
			EditorGUILayout.PropertyField(property, true);
		}

	}
}