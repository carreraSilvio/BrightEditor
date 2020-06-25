using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            GameDataEditorWindow.Open((GameData)target);
        }
        base.OnInspectorGUI();
    }
    
}
