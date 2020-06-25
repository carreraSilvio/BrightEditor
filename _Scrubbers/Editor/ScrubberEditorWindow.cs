﻿using BrightLib.BrightEditing;
using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor Window that mimics the default inspector
/// </summary>
public class ScrubberEditorWindow : BrightEditorWindow
{
    private SerializedObject _serializedObject;
    private SerializedProperty _currentProperty;

    protected SerializedObject SerializedObject { get => _serializedObject; set => _serializedObject = value; }
    protected SerializedProperty CurrentProperty { get => _currentProperty; set => _currentProperty = value; }



    public virtual void OnGUI()
    {
        DrawAllVisibleProperties();

        SerializedObject.ApplyModifiedProperties();
    }

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

    protected void DrawAllVisibleProperties(SerializedObject serializedObject, bool includeChildren = true)
    {
        SerializedProperty prop = serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                DrawProperty(prop, includeChildren);
            }
            while (prop.NextVisible(false));
        }
    }



}


