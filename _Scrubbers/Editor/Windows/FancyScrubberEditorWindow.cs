﻿using UnityEditor;
using UnityEngine;

namespace BrightLib.Scrubbing.Editor
{
    /// <summary>
    /// Fancy version of <see cref="ScrubberEditorWindow"/> with a sidebar
    /// </summary>
    public class FancyScrubberEditorWindow : ScrubberEditorWindow
    {
        private SerializedProperty _selectedProperty;
        private string _selectedPropertyPath;

        public override void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
                {
                    DrawSidebar();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
                {
                    if (_selectedProperty != null)
                    {
                        EditorGUILayout.BeginHorizontal("box");
                        {
                            DrawProperty(_selectedProperty);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    else
                    {
                        EditorGUILayout.LabelField("Select an item from the list");
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();

            SerializedObject.ApplyModifiedProperties();
        }

        protected void DrawSidebar()
        {
            SerializedProperty prop = SerializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    if (string.Equals(prop.name, "m_Script"))
                    {
                        continue;
                    }
                    else
                    {
                        if (GUILayout.Button(prop.displayName))
                        {
                            _selectedPropertyPath = prop.propertyPath;
                        }
                    }
                }
                while (prop.NextVisible(false));
            }

            if (!string.IsNullOrEmpty(_selectedPropertyPath))
            {
                _selectedProperty = SerializedObject.FindProperty(_selectedPropertyPath);
            }
        }
    }
}