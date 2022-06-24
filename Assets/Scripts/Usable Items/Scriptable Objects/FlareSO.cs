using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Flare", menuName = "Items/Flares/New Flare")]
public class FlareSO : ItemSO
{
    [Header("Item behaviour")]
    public GameObject flareToDropPb;
}

[CustomEditor(typeof(FlareSO))]
public class FlareEditor : ItemEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);

        FlareSO so = (FlareSO)target;

        //Item behaviour
        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);

        //Flare prefab
        so.flareToDropPb = (GameObject)EditorGUILayout.ObjectField("Flare Prefab", so.flareToDropPb, typeof(GameObject), allowSceneObjects: false);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
