using UnityEditor;
using UnityEditor.Callbacks;

public class GameDataEditorWindow : ExtendedEditorWindow
{
    public static void Open(GameData gameData)
    {
        GameDataEditorWindow wnd = GetWindow<GameDataEditorWindow>(gameData.name) ;
        wnd.serializedObject = new SerializedObject(gameData);
    }

    private void OnGUI()
    {

        //var it = serializedObject.GetIterator();

        //do
        //{
        //    //Debug.Log(it.name);
        //    Debug.Log(it.propertyType);
        //    //DrawField(it.propertyPath, false);
        //} while (it.Next(true));

        DrawField("intTest", false);
        DrawField("stringTest", false);
        DrawField("gameData", false);
        //currentProperty = serializedObject.FindProperty("gameData");
        //DrawProperties(currentProperty, true);

        //serializedObject.GetIterator

        //currentProperty = serializedObject.FindProperty("gameData");

        //EditorGUILayout.BeginHorizontal();

        //EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        //DrawSidebar(currentProperty);

        //EditorGUILayout.EndVertical();

        //EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        //if(selectedProperty != null)
        //{
        //    DrawProperties(selectedProperty, true);
        //    //DrawSelectedPropertiesPanel();
        //}
        //else
        //{
        //    EditorGUILayout.LabelField("Select an item from the list");
        //}
        //EditorGUILayout.EndVertical();
        //EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawSelectedPropertiesPanel()
    {
        currentProperty = selectedProperty;

        EditorGUILayout.BeginHorizontal("box");

        DrawField("name", true);

        EditorGUILayout.EndHorizontal();
    }
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