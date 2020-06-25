using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SkillData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Scrubber"))
        {
            Scrubber.OpenScrubberEditorWindow((SkillData)target);
        }
        if (GUILayout.Button("Open Fancy Scrubber"))
        {
            Scrubber.OpenFancyScrubberEditorWindow((SkillData)target);
        }
        base.OnInspectorGUI();
    }
    
}
