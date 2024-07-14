using UnityEditor;
using UnityEngine;

public class OpenToolsMenu : EditorWindow
{
    [MenuItem("Tools/Open Tools Menu")]
    public static void ShowWindow()
    {
        GetWindow<OpenToolsMenu>("Tools Menu");
    }

    private void OnGUI()
    {
        GUILayout.Label("Open Tools Menu", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        if (GUILayout.Button("Open Scene Navigator"))
        {
            SceneNavigator.ShowWindow();
        }

        if (GUILayout.Button("Open Select GameObjects by Name"))
        {
            SelectGameObjectsByName.ShowWindow();
        }
        
        if (GUILayout.Button("Open Mesh Combiner Tool"))
        {
            MeshCombinerTool.ShowWindow();
        }
    }
}
