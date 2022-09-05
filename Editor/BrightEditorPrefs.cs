using UnityEditor;
using UnityEngine;

namespace BrightLib.BrightEditing
{
    public class BrightEditorPrefs
    {
        private const string _K_stringDefaultValue = "Blank";

        private string _keyPrefix;

        public BrightEditorPrefs(string keyPrefix)
        {
            _keyPrefix = keyPrefix;
        }

        public void Save(string key, int value)
        {
            SetInt(_keyPrefix + key, value);
        }

        public void Save(string key, float value)
        {
            SetFloat(_keyPrefix + key, value);
        }

        public void Save(string key, bool value)
        {
            SetBool(_keyPrefix + key, value);
        }

        public void Save(string key, object value)
        {
            SetObject(key, value);
        }

        public void SetFloat(string key, float value)
        {
            EditorPrefs.SetFloat(_keyPrefix + key, value);
        }

        public float GetFloat(string key, float defaultValue = 0)
        {
            return EditorPrefs.GetFloat(_keyPrefix + key, defaultValue);
        }

        public void SetInt(string key, int value)
        {
            EditorPrefs.SetInt(_keyPrefix + key, value);
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            return EditorPrefs.GetInt(_keyPrefix + key, defaultValue);
        }

        public void SetBool(string key, bool value)
        {
            EditorPrefs.SetBool(_keyPrefix + key, value);
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            return EditorPrefs.GetBool(_keyPrefix + key, defaultValue);
        }

        public void SetString(string key, string value)
        {
            EditorPrefs.SetString(_keyPrefix + key, value);
        }

        public string GetString(string key, string defaultValue = _K_stringDefaultValue)
        {
            return EditorPrefs.GetString(_keyPrefix + key, defaultValue);
        }

        public void SetObject(string key, object value)
        {
            SetString(key, JsonUtility.ToJson(value));
        }

        public T GetObject<T>(string key)
        {
            var json = GetString(key);
            var result = JsonUtility.FromJson<T>(json);
            return result;
        }

        public bool HasKey(string key)
        {
            return EditorPrefs.HasKey(_keyPrefix + key);
        }

        public void DeleteKey(string key)
        {
            EditorPrefs.DeleteKey(_keyPrefix + key);
        }
    }
}

