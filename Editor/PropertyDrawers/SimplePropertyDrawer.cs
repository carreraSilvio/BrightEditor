using BrightLib.BrightEditing;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
    public class NewActorCommandDrawer : BrightPropertyDrawer
    {
        private int _dynamicPropertiesTotal = 1;
        private int _baseItemTotal = 1;
        private static readonly float _K_MIN_HEIGHT = 24;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _dynamicPropertiesTotal = 0;
            var rect = position;

            //DrawProperty(ref rect, property, "testString");
            DrawAllVisibleProperties(ref rect, property);

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _K_MIN_HEIGHT + SingleLineHeight * _baseItemTotal + SingleLineHeight * _dynamicPropertiesTotal;
        }

        public void DrawAllVisibleProperties(ref Rect rect, SerializedProperty parentProperty)
        {
            var children = GetVisibleChildren(parentProperty);
            foreach (var child in children)
            {
                //Debug.Log(child.name);
                DrawProperty(ref rect, parentProperty, child.name, 0f, SingleLineHeight);

                _dynamicPropertiesTotal += 1;
            }

        }



        //just a heads-up, might want to do yield return currentProperty.Copy(); instead, otherwise functions like LINQ ToArray() won't work on this function!


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


    }
}