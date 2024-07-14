using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
public class SceneNavigator : EditorWindow
{
    private int currentSceneIndex = 0;
    private string[] sceneNames;

    [MenuItem("Tools/Scene Navigator")]
    public static void ShowWindow()
    {
        GetWindow<SceneNavigator>("Scene Navigator");
    }

    private void OnEnable()
    {
        int sceneCount = EditorBuildSettings.scenes.Length;
        sceneNames = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            string path = EditorBuildSettings.scenes[i].path;
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(path);
            sceneNames[i] = $"{i}: {sceneName}";
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Scene Navigator", EditorStyles.boldLabel);

        if (sceneNames.Length == 0)
        {
            GUILayout.Label("No scenes found in build settings.");
            return;
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Previous Scene"))
        {
            NavigateToPreviousScene();
        }

        if (GUILayout.Button("Next Scene"))
        {
            NavigateToNextScene();
        }
        GUILayout.EndHorizontal();

        int newSceneIndex = EditorGUILayout.Popup("Select Scene:", currentSceneIndex, sceneNames);
        if (newSceneIndex != currentSceneIndex)
        {
            currentSceneIndex = newSceneIndex;
            LoadScene(currentSceneIndex);
        }
    }

    private void NavigateToPreviousScene()
    {
        if (currentSceneIndex > 0)
        {
            currentSceneIndex--;
            LoadScene(currentSceneIndex);
        }
    }

    private void NavigateToNextScene()
    {
        if (currentSceneIndex < sceneNames.Length - 1)
        {
            currentSceneIndex++;
            LoadScene(currentSceneIndex);
        }
    }

    private void LoadScene(int index)
    {
        string scenePath = EditorBuildSettings.scenes[index].path;
        EditorSceneManager.OpenScene(scenePath);
        Debug.Log($"Opened Scene: {sceneNames[index]}");
    }
}
