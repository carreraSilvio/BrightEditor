using System;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace BrightTooling
{
    /// <summary>
    /// Extends <see cref="EditorPrefs"/> with new features.
    /// </summary>
    public sealed class BrightEditorPrefs
    {
        private BrightEditorPrefs() { }

        private static string ConvertToString<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(array[i]);
            }

            return sb.ToString();
        }

        public static void SetColor(string key, Color color)
        {
            EditorPrefs.SetFloat($"{key}_r", color.r);
            EditorPrefs.SetFloat($"{key}_g", color.g);
            EditorPrefs.SetFloat($"{key}_b", color.b);
            EditorPrefs.SetFloat($"{key}_a", color.a);
        }

        public static Color GetColor(string key)
        {
            Color defaultColor = Color.white;

            if (EditorPrefs.HasKey($"{key}_r")
                && EditorPrefs.HasKey($"{key}_g")
                && EditorPrefs.HasKey($"{key}_b")
                && EditorPrefs.HasKey($"{key}_a"))
            {
                return new Color(
                    EditorPrefs.GetFloat($"{key}_r", defaultColor.r),
                    EditorPrefs.GetFloat($"{key}_g", defaultColor.g),
                    PlayerPrefs.GetFloat($"{key}_b", defaultColor.b),
                    EditorPrefs.GetFloat($"{key}_a", defaultColor.a)
                );
            }
            return defaultColor;
        }

        public static void SetObject(string key, object value)
        {
            EditorPrefs.SetString(key, JsonUtility.ToJson(value));
        }

        public static T GetObject<T>(string key)
        {
            var json = EditorPrefs.GetString(key, string.Empty);
            if(string.IsNullOrEmpty(json))
            {
                return default;
            }
            var result = JsonUtility.FromJson<T>(json);
            return result;
        }

        public static void SetArray(string key, object value)
        {
            SetObject(key, value);
        }

        public static T[] GetArray<T>(string key)
        {
            string arrayData = EditorPrefs.GetString(key);

            if (string.IsNullOrEmpty(arrayData))
            {
                return new T[0];
            }

            string[] stringArray = arrayData.Split(',');
            T[] array = new T[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = (T)System.Convert.ChangeType(stringArray[i], typeof(T));
            }

            return array;
        }
    }
}

