using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Flare", menuName = "Items/Flares/New Flare")]
public class FlareSO : ItemSO {
    [Header("Item behaviour")]
    public GameObject flareToDropPb;
}

#if UNITY_EDITOR
[CustomEditor(typeof(FlareSO))]
public class FlareEditor : ItemEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);
        FlareSO so = (FlareSO)target;

        EditorGUILayout.LabelField("Item behaviour", EditorStyles.boldLabel);
        so.flareToDropPb = (GameObject)EditorGUILayout.ObjectField("Flare Prefab", so.flareToDropPb, typeof(GameObject), allowSceneObjects: false);

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif
