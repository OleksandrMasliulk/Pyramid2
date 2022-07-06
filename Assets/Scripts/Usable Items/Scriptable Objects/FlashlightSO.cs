using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Flashlight", menuName = "Items/Flashlights/New Flashlight")]
public class FlashlightSO : ItemSO
{
    [Header("Item Parameters")]
    public GameObject flashlightPrefab;
}

#if UNITY_EDITOR
[CustomEditor(typeof(FlashlightSO))]
public class FlashlightEditor : ItemEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);

        FlashlightSO so = (FlashlightSO)target;

        //Item behaviour
        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);

        //Flashlight prefab
        so.flashlightPrefab = (GameObject)EditorGUILayout.ObjectField("Flashlight Prefab", so.flashlightPrefab, typeof(GameObject), allowSceneObjects: false);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif
