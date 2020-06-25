using System;
using UnityEditor;
using UnityEditor.Callbacks;

public class GameDataEditorWindow : FancyScrubberEditorWindow
{
    //public static void Open(SkillData skillData)
    //{
    //    GameDataEditorWindow wnd = EditorWindow.CreateWindow<GameDataEditorWindow>(new Type[] { typeof(GameDataEditorWindow) });
    //    wnd.titleContent = new UnityEngine.GUIContent(skillData.name);
    //    wnd.SerializedObject = new SerializedObject(skillData);
    //}

    //private void OnGUI()
    //{
    //    DrawAllVisibleProperties();

    //    SerializedObject.ApplyModifiedProperties();
    //}

    //[OnOpenAsset()]
    //public static bool OpenEditor(int instanceId, int line)
    //{
    //    SkillData obj = EditorUtility.InstanceIDToObject(instanceId) as SkillData;
    //    if (obj != null)
    //    {
    //        GameDataEditorWindow.Open(obj);
    //        return true;
    //    }
    //    return false;
    //}
}