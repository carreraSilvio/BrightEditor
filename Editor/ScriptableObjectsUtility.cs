﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace BrightTooling
{
    public sealed class ScriptableObjectsUtility
    {
        private ScriptableObjectsUtility() { }

        /// <summary>
        /// Load all ScriptableObjects of type
        /// </summary>
        public static T[] LoadAssetsFromResources<T>() where T : ScriptableObject
        {
            return Resources.FindObjectsOfTypeAll<T>();
        }

        /// <summary>
        /// Load all SO of type from Assets
        /// </summary>
        public static T[] LoadAssets<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] assets = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                assets[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return assets;
        }

        /// <inheritdoc cref="CreateAsset{T}(string, string)"/>
        public static T CreateAsset<T>(string name) where T : ScriptableObject
        {
            return CreateAsset<T>(name, "Assets");
        }

        /// <summary>
        /// Create ScriptableObject asset of name in folder
        /// </summary>
        public static T CreateAsset<T>(string name, string folder) where T : ScriptableObject
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.LogError("ScriptableObjectUtility caused: Create Asset failed because Name is empty");
                return null;
            }

            string path = folder + "/" + name.Trim() + ".asset";

            var instance = ScriptableObject.CreateInstance<T>();

            var fullPath = Path.GetFullPath(path);
            var directory = Path.GetDirectoryName(fullPath);
            if (directory != null)
            {
                Directory.CreateDirectory(directory);
            }

            AssetDatabase.CreateAsset(instance, AssetDatabase.GenerateUniqueAssetPath(path));

            AssetDatabase.SaveAssets();

            Debug.Log("Scriptable object asset created at " + path);

            return instance;
        }

        public static T CreateAssetWithFolderDialog<T>(string filename) where T : ScriptableObject
        {
            var path = EditorUtility.SaveFolderPanel("Where to save", "Assets/", "");
            if (path.Length <= 0)
            {
                return null;
            }

            var relativePath = "Assets" + path.Substring(Application.dataPath.Length);

            return CreateAsset<T>(filename, relativePath);
        }

        public static void NestObject(Object childObject, Object parentObject)
        {
            AssetDatabase.AddObjectToAsset(childObject, parentObject);

            // Reimport the asset after adding an object.
            // Otherwise the change only shows up when saving the project
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(childObject));

            // Print the path of the created asset
            Debug.Log(AssetDatabase.GetAssetPath(childObject));
        }
    }
}