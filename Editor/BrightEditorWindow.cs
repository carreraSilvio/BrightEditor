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

        /// <inheritdoc cref="BrightEditorUtility.DrawInt"/>
        public static int DrawInt(string label, int value) => BrightEditorUtility.DrawInt(label, value);

        #endregion

        #region Draw Text

        /// <inheritdoc cref="BrightEditorUtility.DrawTextField"/>
        public static string DrawTextField(string label, string text, params GUILayoutOption[] options)
            => BrightEditorUtility.DrawTextField(label, text, options);

        /// <inheritdoc cref="BrightEditorUtility.DrawBoldLabel"/>
        protected void DrawBoldLabel(string text, params GUILayoutOption[] options)
            => BrightEditorUtility.DrawBoldLabel(text, options);

        /// <inheritdoc cref="BrightEditorUtility.DrawTextArea"/>
        protected string DrawTextArea(string label, string text, params GUILayoutOption[] options)
            => BrightEditorUtility.DrawTextArea(text, text, options);

        #endregion

        /// <inheritdoc cref="BrightEditorUtility.DrawButton"/>
        protected bool DrawButton(string text, float width = 60, float height = 20)
            => DrawButton(text, GUILayout.Width(width), GUILayout.Height(height));

        /// <inheritdoc cref="BrightEditorUtility.DrawButton"/>
        protected bool DrawButton(string text, params GUILayoutOption[] options)
            => BrightEditorUtility.DrawButton(text, options);


        /// <inheritdoc cref="BrightEditorUtility.DrawSimpleButton"/>
        public static bool DrawSimpleButton(string text)
            => BrightEditorUtility.DrawSimpleButton(text);


        public static void DrawProperty(SerializedObject serializedObject, string propertyName, bool includeChildren = true)
            => BrightEditorUtility.DrawProperty(serializedObject, propertyName, includeChildren);

        public static void DrawProperty(SerializedProperty property, bool includeChildren = true)
            => BrightEditorUtility.DrawProperty(property, includeChildren);


        public void DrawHelpBox(string message, MessageType messageType = MessageType.None, bool wide = false)
            => BrightEditorUtility.DrawHelpBox(message, messageType, wide);

        /// <inheritdoc cref="BrightEditorUtility.BeginReadOnlyArea"/>
        public void BeginReadOnlyArea(bool toggle = true) => BrightEditorUtility.BeginReadOnlyArea(toggle);

        /// <inheritdoc cref="BrightEditorUtility.EndReaOnlyArea"/>
        public void EndReadOnlyArea() => BrightEditorUtility.EndReaOnlyArea();

        /// <inheritdoc cref="BrightEditorUtility.IncreaseIndentLevel"/>
        public void IncreaseIndentLevel() => BrightEditorUtility.IncreaseIndentLevel();

        /// <inheritdoc cref="BrightEditorUtility.DecreaseIndentLevel"/>
        public void DecreaseIndentLevel() => BrightEditorUtility.DecreaseIndentLevel();

        /// <inheritdoc cref="BrightEditorUtility.ResetIndentLevel"/>
        public void ResetIndentLevel() => BrightEditorUtility.ResetIndentLevel();


    }

}