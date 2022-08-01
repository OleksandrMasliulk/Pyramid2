using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Medkit", menuName = "Items/Medkits/New Medkit")]
public class MedkitSO : ItemSO {
    [Header("Item Parameters")]
    public int restoreAmount;
}

#if UNITY_EDITOR
[CustomEditor(typeof(MedkitSO))]
public class MedkitEditor : ItemEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);
        MedkitSO so = (MedkitSO)target;

        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);
        so.restoreAmount = EditorGUILayout.IntField("Restore amount", so.restoreAmount);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif
