using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Paint", menuName = "Items/Paints/New Paint")]
public class PaintSO : ItemSO
{
}

#if UNITY_EDITOR
[CustomEditor(typeof(PaintSO))]
public class PaintEditor : ItemEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);

        PaintSO so = (PaintSO)target;

        //Item behaviour
        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif