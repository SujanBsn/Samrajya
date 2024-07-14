using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SelectGameObjectsByName : EditorWindow
{
    private string searchName = "";
    private bool exactMatch = true;

    [MenuItem("Tools/Select GameObjects by Name")]
    public static void ShowWindow()
    {
        GetWindow<SelectGameObjectsByName>("Select GameObjects by Name");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select GameObjects by Name", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        // Search field
        GUILayout.Label("Search Settings:", EditorStyles.boldLabel);
        searchName = EditorGUILayout.TextField("Name:", searchName);
        exactMatch = EditorGUILayout.Toggle("Exact Match", exactMatch);

        EditorGUILayout.Space();

        // Select button
        if (GUILayout.Button("Select GameObjects"))
        {
            SelectGameObjects();
        }
    }

    private void SelectGameObjects()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> objectsToSelect = new();

        foreach (GameObject obj in allObjects)
        {
            if (exactMatch)
            {
                if (obj.name == searchName)
                {
                    objectsToSelect.Add(obj);
                }
            }
            else
            {
                if (obj.name.Contains(searchName))
                {
                    objectsToSelect.Add(obj);
                }
            }
        }

        // Select all found objects
        Selection.objects = objectsToSelect.ToArray();

        Debug.Log($"Selected {objectsToSelect.Count} GameObjects with name '{searchName}'.");
    }
}
