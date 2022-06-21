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

    public bool GenerateID(out int ID)
    {
        int iterations = 1000;
        for (int i = 0; i < iterations; i++)
        {
            ID = Random.Range(0, 1000);
            if (!GetItemsIDs().Contains(ID))
            {
                return true;
            }
        }

        ID = -1;
        return false;
    }
}

[CustomEditor(typeof(ItemSO))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemSO so = (ItemSO)target;
        if (GUILayout.Button("Generate ID"))
        {
            if (so.GenerateID(out int ID))
            {
                so.itemID = ID;
            }
            else
            {
                so.itemID = ID;
                EditorGUILayout.LabelField("FAILED!");
            }

        }
        DrawDefaultInspector();
    }
}

[CustomEditor(typeof(FlareSO))]
public class FlareEditor : ItemEditor
{
}
[CustomEditor(typeof(MedkitSO))]
public class MedkitEditor : ItemEditor
{
}
[CustomEditor(typeof(FlashlightSO))]
public class FlashlightEditor : ItemEditor
{
}
[CustomEditor(typeof(PaintSO))]
public class PaintEditor : ItemEditor
{
}
[CustomEditor(typeof(TreasureSO))]
public class TreasureEditor : ItemEditor
{
}




