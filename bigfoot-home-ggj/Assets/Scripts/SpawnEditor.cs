﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(SpawnContainer))]
public class SpawnEditor : Editor {

    private static bool EditorEnabled = false;
    private GameObject SpawnPrefab;
    private GameObject SpawnParent;

    //If Enable Editor is checked, select a GameObject with SpawnContainer component, then click somewhere in the Scene view
    //to spawn a spawn point

    void OnSceneGUI()
    {
        if (EditorEnabled)
        {
            if (Event.current.type == EventType.MouseDown)
            {
                Ray r = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(r, out hitInfo))
                {
                    SpawnParent = GameObject.Find("Spawns");
                    SpawnPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Spawn.prefab", typeof(GameObject));
                    GameObject newPoint = GameObject.Instantiate(SpawnPrefab);
                    newPoint.transform.position = hitInfo.point + new Vector3 (0f, 0.5f, 0f);
                    newPoint.transform.parent = SpawnParent.transform;
                }
            }
        }
    }
	
    
    public override void OnInspectorGUI(){
        EditorEnabled = GUILayout.Toggle(EditorEnabled, "Enable Editor");
    }
}