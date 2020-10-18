using System;
using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
    /// <summary>
    /// Utility class with that wraps <see cref="GUI"/>, <see cref="GUILayout"/>, <see cref="EditorGUI"/> and <see cref="EditorGUILayout"/> methods. 
    /// </summary>
    public sealed class BrightEditorUtility
    {
        private BrightEditorUtility() { }

        #region Draw Int

        /// <summary>
        /// Draws an int field
        /// </summary>
        public static int DrawInt(string label, int value)
            => EditorGUILayout.IntField(label, value);

        #endregion

        #region Draw Text

        /// <summary>
        /// Draws a text field 
        /// </summary>
        public static string DrawTextField(string label, string text, params GUILayoutOption[] options)
            => EditorGUILayout.TextField(label, text, options);

        /// <summary>
        /// Draws a label with bold applied.
        /// </summary>
        public static void DrawBoldLabel(string text, params GUILayoutOption[] options)
            => EditorGUILayout.LabelField(text, EditorStyles.boldLabel, options);


        /// <summary>
        /// Draws a text area with a label.
        /// </summary>
        public static string DrawTextArea(string label, string text, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label);
            return EditorGUILayout.TextArea(text, options);
        }

        #endregion

        #region Draw Button

        /// <summary>
        /// Draws a button and returns true if it was pressed this frame.
        /// </summary>
        public static bool DrawButton(string text, float width = 60, float height = 20)
            => GUILayout.Button(text, GUILayout.Width(width), GUILayout.Height(height));

        /// <summary>
        /// Draws a button and returns true if it was pressed this frame.
        /// </summary>
        public static bool DrawButton(string text, params GUILayoutOption[] options)
            => GUILayout.Button(text, options);

        /// <summary>
        /// Draws a button and returns true if it was pressed this frame.
        /// </summary>
        public static bool DrawSimpleButton(string text)
            => GUILayout.Button(text);


        /// <summary>
        /// Draws a button with a prefix label on the same line.
        /// </summary>
        public static bool DrawInlineButton(string prefixLabelText, string buttonText, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(prefixLabelText);
            var result = GUILayout.Button(buttonText, options);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        #endregion

        #region Draw Property

        public static void DrawProperty(SerializedObject serializedObject, string propertyName, bool includeChildren = true)
        {
            SerializedProperty property = serializedObject.FindProperty(propertyName);
            DrawProperty(property, includeChildren);
        }

        public static void DrawProperty(SerializedProperty property, bool includeChildren = true)
        {
            EditorGUILayout.PropertyField(property, includeChildren);
        }

        public static SerializedProperty FetchProperty(SerializedObject serializedObject, string propertyName)
        {
            var property = serializedObject.FindProperty(propertyName);
            if (property == null) Debug.LogWarning($"{propertyName} not found in object {serializedObject.targetObject.name}");

            return property;
        }

        #endregion

        #region Draw Helpbox

        public static void DrawHelpBox(string message, MessageType messageType = MessageType.None, bool wide = false)
            => EditorGUILayout.HelpBox(message, messageType, wide);

        #endregion

        #region Draw Script Field

        public static void DrawScriptField(MonoBehaviour target)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(target), target.GetType(), false);
            GUI.enabled = true;
        }

        public static void DrawScriptField(ScriptableObject target)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject(target), target.GetType(), false);
            GUI.enabled = true;
        }

        #endregion

        #region Draw Browse Buttons

        /// <summary>
        /// Creates a filepath textfield with a browse button. Opens the open file panel.
        /// </summary>
        public static string BrowsFileLabel(string name, float labelWidth, string path, string extension)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(name, GUILayout.MaxWidth(labelWidth));
            string filepath = EditorGUILayout.TextField(path);
            if (GUILayout.Button("Browse"))
            {
                filepath = EditorUtility.OpenFilePanel(name, path, extension);
            }

            EditorGUILayout.EndHorizontal();
            return filepath;
        }

        /// <summary>
        /// Creates a folder path textfield with a browse button. Opens the save folder panel.
        /// </summary>
        public static string BrowseFolderLabel(string name, float labelWidth, string path)
        {
            EditorGUILayout.BeginHorizontal();
            string filepath = EditorGUILayout.TextField(name, path, GUILayout.MaxWidth(labelWidth));
            if (GUILayout.Button("Browse", GUILayout.MaxWidth(60)))
            {
                filepath = EditorUtility.SaveFolderPanel(name, path, "Folder");
            }

            EditorGUILayout.EndHorizontal();
            return filepath;
        }

        #endregion

        /// <summary>
        /// Allow fields after this to be seen but not altered via inspector.
        /// </summary>
        public static void StartGreyedOutArea(bool toggle = true) => GUI.enabled = !toggle;

        /// <summary>
        /// Allow fields after this to be seen and altered via inspector.
        /// </summary>
        public static void EndGreyedOutArea() => GUI.enabled = true;

        /// <summary>
        /// Increase indent level by 1
        /// </summary>
        public static void IncreaseIndentLevel() => EditorGUI.indentLevel++;

        /// <summary>
        /// Decrease indent level by 1
        /// </summary>
        public static void DecreaseIndentLevel() => EditorGUI.indentLevel--;

        /// <summary>
        /// Set indent level back to 0
        /// </summary>
        public static void ResetIndentLevel() => EditorGUI.indentLevel = 0;

        /// <summary>
        /// Sets the default label width to the given width
        /// </summary>
        public static void SetLabelWidth(float labelWidth) => EditorGUIUtility.labelWidth = labelWidth;

        /// <summary>
        /// Set default label width back to the default value. See <see cref="EditorGUIUtility.labelWidth"/>
        /// </summary>
        public static void ResetLabelWidth() => SetLabelWidth(0f);


        public static class EditorIcons
        {
            public static GUIContent Plus => EditorGUIUtility.IconContent("Toolbar Plus");
            public static GUIContent Minus => EditorGUIUtility.IconContent("Toolbar Minus");
            public static GUIContent Refresh => EditorGUIUtility.IconContent("Refresh");

            public static GUIContent ConsoleInfo => EditorGUIUtility.IconContent("console.infoicon.sml");
            public static GUIContent ConsoleWarning => EditorGUIUtility.IconContent("console.warnicon.sml");
            public static GUIContent ConsoleError => EditorGUIUtility.IconContent("console.erroricon.sml");

            public static GUIContent Check => EditorGUIUtility.IconContent("FilterSelectedOnly");
            public static GUIContent Cross => EditorGUIUtility.IconContent("d_winbtn_win_close");
            public static GUIContent CheckGreen => EditorGUIUtility.IconContent("vcs_check");
            public static GUIContent CrossRed => EditorGUIUtility.IconContent("vcs_delete");

            public static GUIContent EyeOn => EditorGUIUtility.IconContent("d_VisibilityOn");
            public static GUIContent EyeOff => EditorGUIUtility.IconContent("d_VisibilityOff");
            public static GUIContent Zoom => EditorGUIUtility.IconContent("d_ViewToolZoom");

            public static GUIContent Help => EditorGUIUtility.IconContent("_Help");
            public static GUIContent Favourite => EditorGUIUtility.IconContent("Favorite");
            public static GUIContent Label => EditorGUIUtility.IconContent("FilterByLabel");

            public static GUIContent Settings => EditorGUIUtility.IconContent("d_Settings");
            public static GUIContent SettingsPopup => EditorGUIUtility.IconContent("_Popup");
            public static GUIContent SettingsMixer => EditorGUIUtility.IconContent("Audio Mixer");

            public static GUIContent Circle => EditorGUIUtility.IconContent("TestNormal");
            public static GUIContent CircleYellow => EditorGUIUtility.IconContent("TestInconclusive");
            public static GUIContent CircleDotted => EditorGUIUtility.IconContent("TestIgnored");
            public static GUIContent CircleRed => EditorGUIUtility.IconContent("TestFailed");
        }

        #region Characters

        public static class Characters
        {
            public const string ArrowUp = "▲";

            public const string ArrowDown = "▼";

            public const string ArrowLeft = "◀";

            public const string ArrowRight = "▶";

            public const string ArrowLeftLight = "←";

            public const string ArrowRightLight = "→";

            public const string ArrowTopRightLight = "↘";

            public const string Check = "✓";

            public const string Cross = "×";

            public const string Plus = "+";

            public const string Minus = "-";

        }

        #endregion

        #region Predefined Buttons

        /// <summary>
        /// Display Button with ArrowUI
        /// </summary>
        public static bool DrawUpButton()
        {
            return GUILayout.Button(Characters.ArrowUp, EditorStyles.toolbarButton, GUILayout.Width(18));
        }

        public static bool DrawDownButton()
        {
            return GUILayout.Button(Characters.ArrowDown, EditorStyles.toolbarButton, GUILayout.Width(18));
        }

        public static bool DrawPlusButton()
        {
            return GUILayout.Button(Characters.Plus, EditorStyles.toolbarButton, GUILayout.Width(18));
        }


        public static bool DrawCrossButton()
        {
            return GUILayout.Button(Characters.Cross, EditorStyles.toolbarButton, GUILayout.Width(18));
        }

        #endregion

        /// <summary>
        /// Creates a toolbar that is filled in from an Enum. Useful for setting tool modes.
        /// </summary>
        public static Enum DrawEnumToolbar(Enum selected)
        {
            string[] toolbar = Enum.GetNames(selected.GetType());
            Array values = Enum.GetValues(selected.GetType());

            for (int i = 0; i < toolbar.Length; i++)
            {
                string toolName = toolbar[i];
                toolName = toolName.Replace("_", " ");
                toolbar[i] = toolName;
            }

            int selectedIndex = 0;
            while (selectedIndex < values.Length)
            {
                if (selected.ToString() == values.GetValue(selectedIndex).ToString())
                {
                    break;
                }

                selectedIndex++;
            }

            selectedIndex = GUILayout.Toolbar(selectedIndex, toolbar);
            return (Enum)values.GetValue(selectedIndex);
        }

    }

}