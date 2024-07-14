using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class MeshCombinerTool : EditorWindow
{
    private List<MeshFilter> listMeshFilter = new List<MeshFilter>();

    [MenuItem("Tools/Mesh Combiner Tool")]
    public static void ShowWindow()
    {
        GetWindow<MeshCombinerTool>("Mesh Combiner Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Mesh Combiner Tool", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("Drag GameObjects with MeshFilters to combine into the list below. Click 'Combine and Save' to create a combined mesh and save it to a specified location.", MessageType.Info);

        EditorGUILayout.Space();

        Rect dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
        GUI.Box(dropArea, "Drag GameObjects here to add to the list");

        Event currentEvent = Event.current;

        switch (currentEvent.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (!dropArea.Contains(currentEvent.mousePosition))
                    break;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (currentEvent.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    foreach (Object draggedObject in DragAndDrop.objectReferences)
                    {
                        GameObject draggedGameObject = draggedObject as GameObject;
                        if (draggedGameObject != null)
                        {
                            MeshFilter meshFilter = draggedGameObject.GetComponent<MeshFilter>();
                            if (meshFilter != null && !listMeshFilter.Contains(meshFilter))
                            {
                                listMeshFilter.Add(meshFilter);
                            }
                        }
                    }
                }

                Event.current.Use();
                break;
        }

        EditorGUILayout.Space();

        // Draw list of MeshFilters
        for (int i = 0; i < listMeshFilter.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            listMeshFilter[i] = EditorGUILayout.ObjectField($"MeshFilter {i + 1}:", listMeshFilter[i], typeof(MeshFilter), true) as MeshFilter;
            if (GUILayout.Button("-", GUILayout.Width(20)))
            {
                listMeshFilter.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        // Combine and Save button
        if (GUILayout.Button("Combine and Save"))
        {
            CombineAndSaveMesh();
        }
    }

    private void CombineAndSaveMesh()
    {
        if (listMeshFilter.Count == 0)
        {
            EditorUtility.DisplayDialog("Error", "No source MeshFilters added to combine!", "OK");
            return;
        }

        // Make an array of CombineInstance
        CombineInstance[] combine = new CombineInstance[listMeshFilter.Count];

        // Set Mesh and their Transform to the CombineInstance
        for (int i = 0; i < listMeshFilter.Count; i++)
        {
            if (listMeshFilter[i] != null)
            {
                combine[i].mesh = listMeshFilter[i].sharedMesh;
                combine[i].transform = listMeshFilter[i].transform.localToWorldMatrix;
            }
            else
            {
                Debug.LogWarning($"MeshFilter {i + 1} is not assigned and will be skipped in the combine operation.");
            }
        }

        // Create a new GameObject with a MeshFilter
        GameObject combinedObject = new GameObject("CombinedMesh");
        MeshFilter combinedMeshFilter = combinedObject.AddComponent<MeshFilter>();

        // Create a new Mesh
        Mesh combinedMesh = new Mesh();

        // Call CombineMeshes and pass in the array of CombineInstance
        combinedMesh.CombineMeshes(combine);

        // Assign the combined mesh to the MeshFilter
        combinedMeshFilter.sharedMesh = combinedMesh;

        // Save the combined mesh
        SaveMesh(combinedMesh, "CombinedMesh", false, true);

        // Destroy the combined GameObject if desired
        // DestroyImmediate(combinedObject);

        // Print result
        Debug.Log("<color=#20E7B0>Combine and Save Mesh was Successful!</color>");
    }

    private void SaveMesh(Mesh mesh, string name, bool makeNewInstance, bool optimizeMesh)
    {
        string path = EditorUtility.SaveFilePanel("Save Separate Mesh Asset", "Assets/Materials/Meshes", name, "asset");
        if (string.IsNullOrEmpty(path)) return;

        path = FileUtil.GetProjectRelativePath(path);

        Mesh meshToSave = (makeNewInstance) ? Object.Instantiate(mesh) as Mesh : mesh;

        if (optimizeMesh)
            MeshUtility.Optimize(meshToSave);

        AssetDatabase.CreateAsset(meshToSave, path);
        AssetDatabase.SaveAssets();
    }
}
