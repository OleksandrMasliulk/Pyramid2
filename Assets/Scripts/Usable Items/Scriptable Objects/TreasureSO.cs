using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Items/Treasures/New Treasure")]
public class TreasureSO : ItemSO {
    [Header("Item Parameters")]
    public int value;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TreasureSO))]
public class TreasureEditor : ItemEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);
        TreasureSO so = (TreasureSO)target;

        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);
        so.value = EditorGUILayout.IntField("Treasure value", so.value);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif
