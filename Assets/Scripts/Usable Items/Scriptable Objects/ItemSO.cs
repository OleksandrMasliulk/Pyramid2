using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class ItemSO : ScriptableObject
{
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
    public bool useOnRelease;
    public GameObject dropPrefab;

    private List<int> GetItemsIDs()
    {
        ItemSO[] SOs = Resources.LoadAll<ItemSO>("ItemsSO");
        List<ItemSO> SOList = new List<ItemSO>(SOs);
        SOList.Remove(this);

        List<int> IDs = new List<int>();

        foreach(ItemSO so in SOList)
        {
            IDs.Add(so.itemID);
        }

        return IDs;
    }

    public bool GenerateID()
    {
        List<int> IDs = GetItemsIDs();
        int iterations = 1000;
        for (int i = 0; i < iterations; i++)
        {
            int ID = Random.Range(0, 1000);
            if (!IDs.Contains(ID))
            {
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
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemSO so = (ItemSO)target;
        GUI.changed = false;

        EditorGUILayout.BeginVertical();

        #region GENERAL OPTIONS       
        //GENERAL OPTIONS
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);

        //Item type
        so.type = (Item.ItemType)EditorGUILayout.EnumPopup("Type", so.type);
        //ID
        GUI.enabled = false;
        so.itemID = EditorGUILayout.IntField("ID", so.itemID);
        GUI.enabled = true;
        if (GUILayout.Button("Generate ID"))
        {
            if (!so.GenerateID())
            {
                EditorGUILayout.LabelField("FAILED!");
            }
        }
        #endregion
        EditorGUILayout.Space(10);
        #region GRAPHICS OPTIONS
        //GRAPHICS OPTIONS
        EditorGUILayout.LabelField("Graphics", EditorStyles.boldLabel);

        //Inventory icon
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Inventory icon");
        so.inventoryIcon = (Sprite)EditorGUILayout.ObjectField(so.inventoryIcon, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();
        #endregion
        EditorGUILayout.Space(10);
        #region INVENTORY BEHAVIOUR OPTIONS
        //INVENTORY BEHAVIOUR
        EditorGUILayout.LabelField("Inventory behaviour", EditorStyles.boldLabel);

        //Is item stackable
        so.isStackable = EditorGUILayout.Toggle("Is Stackable", so.isStackable);
        if (so.isStackable)
        {
            so.maxStack = EditorGUILayout.IntField("Max stack count", so.maxStack);
        }
        //Is Item consumable
        so.isConsumable = EditorGUILayout.Toggle("Is Consumable", so.isConsumable);
        //Use on release
        so.useOnRelease = EditorGUILayout.Toggle("Use On Release", so.useOnRelease);
        //Item drop prefab
        so.dropPrefab = (GameObject)EditorGUILayout.ObjectField("Item drop prefab", so.dropPrefab, typeof(GameObject), allowSceneObjects: false);
        #endregion

        EditorGUILayout.EndVertical();

        if (GUI.changed)
            EditorUtility.SetDirty(so);
    }
}
#endif




