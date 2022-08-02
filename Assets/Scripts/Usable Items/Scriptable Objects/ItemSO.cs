using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AddressableAssets;
using System.Linq;

public abstract class ItemSO : ScriptableObject {
    [Header("General")]
    public Item.ItemType type;
    [ReadOnly]
    public int itemID;

    [Header("Graphics")]
    public Sprite inventoryIcon;

    [Header("Inventory behaviour")]
    public bool isStackable;
    public int maxStack;
    public bool isConsumable;
    public GameObject dropPrefab;

    private List<int> GetItemsIDs() {
        List<ItemSO> list = new List<ItemSO>();
        var op = Addressables.LoadAssetsAsync<ItemSO>("Item", null);
        op.Completed += (op) => list.AddRange(op.Result);
        List<int> IDs = new List<int>();
        foreach(ItemSO so in list.Except(new List<ItemSO> {this}))
            IDs.Add(so.itemID);

        return IDs;
    }

    public bool GenerateID() {
        List<int> IDs = GetItemsIDs();
        int iterations = 1000;
        for (int i = 0; i < iterations; i++) {
            int ID = Random.Range(0, 1000);
            if (!IDs.Contains(ID)) {
                itemID = ID;
                return true;
            }
        }

        itemID = -1;
        return false;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ItemSO))]
public class ItemEditor : Editor {
    public override void OnInspectorGUI() {
        ItemSO so = (ItemSO)target;
        GUI.changed = false;

        EditorGUILayout.BeginVertical();

        #region GENERAL OPTIONS       
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);

        so.type = (Item.ItemType)EditorGUILayout.EnumPopup("Type", so.type);
        GUI.enabled = false;
        so.itemID = EditorGUILayout.IntField("ID", so.itemID);
        GUI.enabled = true;
        if (GUILayout.Button("Generate ID")) {
            if (!so.GenerateID())
                EditorGUILayout.LabelField("FAILED!");
        }
        #endregion

        EditorGUILayout.Space(10);

        #region GRAPHICS OPTIONS
        EditorGUILayout.LabelField("Graphics", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Inventory icon");
        so.inventoryIcon = (Sprite)EditorGUILayout.ObjectField(so.inventoryIcon, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(10);

        #region INVENTORY BEHAVIOUR OPTIONS
        EditorGUILayout.LabelField("Inventory behaviour", EditorStyles.boldLabel);

        so.isStackable = EditorGUILayout.Toggle("Is Stackable", so.isStackable);
        if (so.isStackable)
            so.maxStack = EditorGUILayout.IntField("Max stack count", so.maxStack);
        so.isConsumable = EditorGUILayout.Toggle("Is Consumable", so.isConsumable);
        so.dropPrefab = (GameObject)EditorGUILayout.ObjectField("Item drop prefab", so.dropPrefab, typeof(GameObject), allowSceneObjects: false);
        #endregion

        EditorGUILayout.EndVertical();

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif




