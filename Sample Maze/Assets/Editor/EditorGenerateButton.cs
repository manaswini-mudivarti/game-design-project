using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MazeGenerator))]
public class EditorGenerateButton : Editor
{
    public override void OnInspectorGUI()
    {
        MazeGenerator generator = (MazeGenerator)target;
        if (DrawDefaultInspector() && generator.autoUpdate)
        {
            DestroyChildren(generator);
            generator.GenerateMaze(generator.mazeSize);
        };
        if (GUILayout.Button("Generate"))
        {
            DestroyChildren(generator);
            generator.GenerateMaze(generator.mazeSize);
        }
        if (GUILayout.Button("Destroy"))
        {
            DestroyChildren(generator);
        }
    }

    public void DestroyChildren(MazeGenerator generator)
    {
        Transform transform = generator.transform;
        Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);

    }
}
