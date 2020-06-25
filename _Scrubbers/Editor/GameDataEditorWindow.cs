using System;
using UnityEditor;
using UnityEditor.Callbacks;

public class GameDataEditorWindow : FancyScrubberEditorWindow
{
    public static void Open(GameData gameData)
    {
        GameDataEditorWindow wnd = EditorWindow.CreateWindow<GameDataEditorWindow>(new Type[] { typeof(GameDataEditorWindow) });
        wnd.titleContent = new UnityEngine.GUIContent(gameData.name);
        wnd.SerializedObject = new SerializedObject(gameData);
    }

    //private void OnGUI()
    //{
    //    DrawAllVisibleProperties();

    //    SerializedObject.ApplyModifiedProperties();
    //}

}

public class GameDataAssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        GameData obj = EditorUtility.InstanceIDToObject(instanceId) as GameData;
        if (obj != null)
        {
            GameDataEditorWindow.Open(obj);
            return true;
        }
        return false;
    }
}