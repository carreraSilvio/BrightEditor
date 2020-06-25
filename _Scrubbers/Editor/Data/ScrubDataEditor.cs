using BrightLib.Scrubbing;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScrubData))]
public class ScrubDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Scrubber"))
        {
            Scrubber.OpenScrubberEditorWindow(target);
        }
        if (GUILayout.Button("Open Fancy Scrubber"))
        {
            Scrubber.OpenFancyScrubberEditorWindow(target);
        }
        base.OnInspectorGUI();
    }
    
}
