using BrightLib.BrightEditing;
using UnityEditor;
using UnityEngine;

public class ExtendedEditorWindow : BrightEditorWindow
{
    private SerializedObject _serializedObject;
    private SerializedProperty _currentProperty;

    private string _selectedPropertyPath;
    private SerializedProperty _selectedProperty;
    private string _serializedObjectPath;

    protected SerializedObject SerializedObject { get => _serializedObject; set => _serializedObject = value; }
    protected SerializedProperty CurrentProperty { get => _currentProperty; set => _currentProperty = value; }

    protected string SelectedPropertyPath { get => _selectedPropertyPath; set => _selectedPropertyPath = value; }
    protected SerializedProperty SelectedProperty { get => _selectedProperty; set => _selectedProperty = value; }
    protected string SerializedObjectPath { get => _serializedObjectPath; set => _serializedObjectPath = value; }

    /// <summary>
    /// Draws all visible properties and the script field greyed out. Set <see cref="SerializedObject"/> first
    /// </summary>
    protected void DrawAllVisibleProperties()
    {
        if (_serializedObject == null) return;

        SerializedProperty prop = _serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                if (string.Equals(prop.name, "m_Script"))
                {
                    StartGreyedOutArea();
                    DrawProperty(prop);
                    EndGreyedOutArea();
                }
                else
                {
                    DrawProperty(prop);
                }
            } 
            while (prop.NextVisible(false));
        }
    }

    protected void DrawAllVisibleProperties(SerializedObject serializedObject, bool drawChildren)
    {
        SerializedProperty prop = _serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                DrawProperty(prop);
            } 
            while (prop.NextVisible(false));
        }
    } 

    protected void DrawSidebar(SerializedProperty prop)
    {
        foreach(SerializedProperty p in prop)
        {
            if(GUILayout.Button(p.displayName))
            {
                _selectedPropertyPath = p.propertyPath;
            }
        }

        if(!string.IsNullOrEmpty(_selectedPropertyPath))
        {
            _selectedProperty = _serializedObject.FindProperty(_selectedPropertyPath);
        }
    }

    protected void DrawField(string propName, bool relative)
    {
        if(relative && _currentProperty != null)
        {
            var prop = _currentProperty.FindPropertyRelative(propName);
            if(prop == null)
            {
                Debug.LogWarning($"cant find {propName}");
                return;
            }
            EditorGUILayout.PropertyField(_currentProperty.FindPropertyRelative(propName), true);
        }
        else if(_serializedObject != null)
        {
            EditorGUILayout.PropertyField(_serializedObject.FindProperty(propName), true);
        }
    }

}


