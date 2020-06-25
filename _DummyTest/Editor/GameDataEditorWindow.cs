using UnityEditor;
using UnityEditor.Callbacks;

public class GameDataEditorWindow : ExtendedEditorWindow
{
    public static void Open(GameData gameData)
    {
        GameDataEditorWindow wnd = EditorWindow.CreateWindow<GameDataEditorWindow>() ;
        wnd.titleContent = new UnityEngine.GUIContent(gameData.name);
        wnd.SerializedObject = new SerializedObject(gameData);
    }

    private void OnGUI()
    {
        DrawAllVisibleProperties();

        //SerializedProperty prop = serializedObject.GetIterator();
        //if (prop.NextVisible(true))
        //{
        //    do
        //    {
        //        Debug.Log($"prop. Name {prop.name} Type {prop.propertyType}");
        //        DrawProperties(prop, true);
        //    } while (prop.NextVisible(false));
        //}

        //var currentProperty = _serializedObject.FindProperty("arrayIntTest");
        //DrawProperties(currentProperty, true);

        //var it = serializedObject.GetIterator();
        //it.Next(true);

        //do
        //{
        //    Debug.Log(it.name);
        //    Debug.Log(it.propertyType);
        //    //DrawField(it.propertyPath, false);
        //    var property = it;
        //    DrawProperties(property, true);
        //} while (it.Next(true));

        //DrawField("intTest", false);
        //DrawField("stringTest", false);
        //DrawField("gameData", false);

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

        SerializedObject.ApplyModifiedProperties();
    }

    private void DrawSelectedPropertiesPanel()
    {
        CurrentProperty = SelectedProperty;

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