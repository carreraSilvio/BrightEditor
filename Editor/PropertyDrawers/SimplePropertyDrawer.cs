using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
    /// <summary>
	/// Will draw all visible child properties. Useful when you want a quick default property drawer for lists.
	/// </summary>
    public class SimplePropertyDrawer : BrightPropertyDrawer
    {
        private int _dynamicPropertiesTotal = 1;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _dynamicPropertiesTotal = 0;
            DrawAllVisibleProperties(ref position, property);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return SingleLineHeight + (SingleLineHeight * _dynamicPropertiesTotal);
        }

        public void DrawAllVisibleProperties(ref Rect rect, SerializedProperty parentProperty)
        {
            var children = GetVisibleChildren(parentProperty);
            foreach (var child in children)
            {
                DrawProperty(ref rect, parentProperty, child.name, 0f, SingleLineHeight);

                _dynamicPropertiesTotal += 1;
            }
        }
    }
}