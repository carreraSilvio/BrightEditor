using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
    /// <summary>
    /// Extends <see cref="UnityEditor"/>.<see cref="PropertyDrawer"/> with quality-of-life methods.
    /// </summary>
    public class BrightPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Draw an empty space at rect + offset
        /// </summary>
        protected void DrawSpace(ref Rect baseRect, float offsetY = 0f) => DrawLabel(ref baseRect, "", offsetY);

        protected void DrawLabel(ref Rect baseRect, string text, float increaseY = 0f)
        {
            baseRect.y += increaseY;
            Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

            EditorGUI.LabelField(rect, text);
        }

        protected void DrawBoldLabel(ref Rect baseRect, string text, float increaseY = 0f)
        {
            baseRect.y += increaseY;
            Rect rect = new Rect(baseRect.x, baseRect.y, baseRect.width, SingleLineHeight);

            EditorGUI.LabelField(rect, text, EditorStyles.boldLabel);
        }

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

        protected SerializedProperty FetchPropertyRelative(SerializedProperty property, string propertyRelativeName)
        {
            FetchPropertyRelative(property, propertyRelativeName, out SerializedProperty result);
            return result;
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

        #region GreyedOut Area and Indent Level

        ///<inheritdoc cref="BrightEditorUtility.BeginReadOnlyArea(bool)"/>
        public void BeginReadOnlyArea(bool toggle = true) => BrightEditorUtility.BeginReadOnlyArea(toggle);

        ///<inheritdoc cref="BrightEditorUtility.EndReaOnlyArea"/>
        public void EndReadOnlyArea() => BrightEditorUtility.EndReaOnlyArea();

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

        #endregion

        #region LineHeight and Label Width

        /// <summary>
        /// Get the height used for a single Editor control such as a one-line EditorGUI.TextField
        /// </summary>
        public float SingleLineHeight => EditorGUIUtility.singleLineHeight;

        /// <summary>
        /// Sets the default label width to the given width
        /// </summary>
        public void SetLabelWidth(Rect rect, float rectWidthPercent) => BrightEditorUtility.SetLabelWidth(rect.width * rectWidthPercent);

        /// <summary>
        /// Sets the default label width to the given width
        /// </summary>
        public void SetLabelWidth(float labelWidth) => BrightEditorUtility.SetLabelWidth(labelWidth);

        /// <summary>
        /// Set default label width back to the default value. See <see cref="EditorGUIUtility.labelWidth"/>
        /// </summary>
        public void ResetLabelWidth() => SetLabelWidth(0f);

        #endregion

        #region Alter array

        /// <summary>
        /// Insert an empty element at the end of the array and return it.
        /// </summary>
        public SerializedProperty InsertArrayElement(SerializedProperty propertyArray)
        {
            propertyArray.InsertArrayElementAtIndex(propertyArray.arraySize);
            var newEntry = propertyArray.GetArrayElementAtIndex(propertyArray.arraySize - 1);
            return newEntry;
        }

        /// <summary>
        /// Delete the element at the last index in the array
        /// </summary>
        public bool DeleteArrayElement(SerializedProperty propertyArray)
        {
            if (propertyArray.GetArrayElementAtIndex(propertyArray.arraySize - 1) != null)
            {
                propertyArray.DeleteArrayElementAtIndex(propertyArray.arraySize - 1);
                return true;
            }
            return false;
        }

        #endregion

        #region Get Children Properties

        /// <summary>
        /// Gets all children of `SerializedProperty` at 1 level depth.
        /// </summary>
        /// <param name="serializedProperty">Parent `SerializedProperty`.</param>
        /// <returns>Collection of `SerializedProperty` children.</returns>
        public static IEnumerable<SerializedProperty> GetChildren(SerializedProperty serializedProperty)
        {
            SerializedProperty currentProperty = serializedProperty.Copy();
            SerializedProperty nextSiblingProperty = serializedProperty.Copy();
            {
                nextSiblingProperty.Next(false);
            }

            if (currentProperty.Next(true))
            {
                do
                {
                    if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty))
                        break;

                    yield return currentProperty;
                }
                while (currentProperty.Next(false));
            }
        }

        /// <summary>
        /// Gets visible children of `SerializedProperty` at 1 level depth.
        /// </summary>
        /// <param name="serializedProperty">Parent `SerializedProperty`.</param>
        /// <returns>Collection of `SerializedProperty` children.</returns>
        public static IEnumerable<SerializedProperty> GetVisibleChildren(SerializedProperty serializedProperty)
        {
            SerializedProperty currentProperty = serializedProperty.Copy();
            SerializedProperty nextSiblingProperty = serializedProperty.Copy();
            {
                nextSiblingProperty.NextVisible(false);
            }

            if (currentProperty.NextVisible(true))
            {
                do
                {
                    if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty))
                        break;

                    yield return currentProperty;
                }
                while (currentProperty.NextVisible(false));
            }
        }

        #endregion

    }
}

