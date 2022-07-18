using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class Pickable : MonoBehaviour, IInterractible
{
    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    [SerializeField] private AssetReference _itemSORef;
    private Item _itemToPickUp;

    [SerializeField]private int _count;

    private void Awake()
    {
        Init(_itemSORef);
    }

    private async void Init(AssetReference itemSORef)
    {
        ItemSO itemSO = await itemSORef.LoadAssetAsyncSafe<ItemSO>();

        switch (itemSO.type) 
        {
            case Item.ItemType.Flashlight:
                _itemToPickUp = new Flashlight((FlashlightSO)itemSO);
                break;
            case Item.ItemType.Flare:
                _itemToPickUp = new Flare((FlareSO)itemSO);
                break;
            case Item.ItemType.Medkit:
                _itemToPickUp = new Medkit((MedkitSO)itemSO);
                break;
            case Item.ItemType.Paint:
                _itemToPickUp = new Paint((PaintSO)itemSO);
                break;
            case Item.ItemType.Treasure:
                _itemToPickUp = new Treasure((TreasureSO)itemSO);
                break;
        }

        itemSORef.ReleaseAsset();
    }

    public void SetCount(int count)
    {
        _count = count;
    }

    public void Interract(CharacterBase user)
    {
        PlayerDrivenCharacter player = (PlayerDrivenCharacter)user;

        AddItemCallback callback =  player.InventoryHandler.AddItem(_itemToPickUp, _count);

        switch (callback.Result)
        {
            case AddItemCallback.ResultType.Success:
                Destroy(this.gameObject);
                break;
            case AddItemCallback.ResultType.Partially:
                _count = callback.NotAddedCount;
                break;
            case AddItemCallback.ResultType.Failed:
                break;
        }
    }

    private void OnValidate()
    {
        if (_count <= 0)
            _count = 1;
    }
}
