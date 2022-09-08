using Newtonsoft.Json;
using UnityEditor;

namespace BrightTooling
{
    /// <summary>
    /// Extends <see cref="EditorPrefs"/> with new features.
    /// </summary>
    public sealed class BrightEditorPrefs
    {
        private BrightEditorPrefs() { }

        public void SetObject(string key, object value)
        {
            EditorPrefs.SetString(key, JsonConvert.SerializeObject(value));
        }

        public T GetObject<T>(string key)
        {
            var json = EditorPrefs.GetString(key, string.Empty);
            if(string.IsNullOrEmpty(json))
            {
                return default;
            }
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}

