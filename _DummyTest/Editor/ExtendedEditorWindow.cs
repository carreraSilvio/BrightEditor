using UnityEditor;
using UnityEngine;

public class ExtendedEditorWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;

    private string selectedPropertyPath;
    protected SerializedProperty selectedProperty;


    protected void DrawProperties(SerializedProperty parentProperty, bool drawChildren)
    {
        string lastPropPath = string.Empty;
        foreach(SerializedProperty childProperty in parentProperty)
        {
            if(childProperty.isArray && childProperty.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                childProperty.isExpanded = EditorGUILayout.Foldout(childProperty.isExpanded, childProperty.displayName);
                EditorGUILayout.EndHorizontal();

                if(childProperty.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    DrawProperties(childProperty, drawChildren);
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastPropPath) && childProperty.propertyPath.Contains(lastPropPath)) { continue; }
                lastPropPath = childProperty.propertyPath;
                EditorGUILayout.PropertyField(childProperty, drawChildren);
            }
        }
    }

    protected void DrawSidebar(SerializedProperty prop)
    {
        foreach(SerializedProperty p in prop)
        {
            if(GUILayout.Button(p.displayName))
            {
                selectedPropertyPath = p.propertyPath;
            }
        }

        if(!string.IsNullOrEmpty(selectedPropertyPath))
        {
            selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
        }
    }

    protected void DrawField(string propName, bool relative)
    {
        if(relative && currentProperty != null)
        {
            var prop = currentProperty.FindPropertyRelative(propName);
            if(prop == null)
            {
                Debug.LogWarning($"cant find {propName}");
                return;
            }
            EditorGUILayout.PropertyField(currentProperty.FindPropertyRelative(propName), true);
        }
        else if(serializedObject != null)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(propName), true);
        }
    }

}


