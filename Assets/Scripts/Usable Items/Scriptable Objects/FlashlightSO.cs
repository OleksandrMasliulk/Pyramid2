using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Flashlight", menuName = "Items/Flashlights/New Flashlight")]
public class FlashlightSO : ItemSO
{
    //[Header("Item Parameters")]
    //public Flashlight flashlight;
}

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
    }
}
