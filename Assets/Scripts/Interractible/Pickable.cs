using UnityEngine;
using UnityEngine.AddressableAssets;

public class Pickable : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    [SerializeField] private AssetReference _itemSORef;
    private Item _itemToPickUp;
    [SerializeField] private int _count;

    public async void Init() {
        ItemSO itemSO = await _itemSORef.LoadAssetAsyncSafe<ItemSO>();

        switch (itemSO.type) {
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

        if (!_itemToPickUp.IsStackable)
            _count = 1;
        else if (_count > _itemToPickUp.MaxStack)
            _count = _itemToPickUp.MaxStack;

        _itemSORef.ReleaseAssetSafe();
    }

    public void Init(Item item, int count) {
        _itemToPickUp = item;
        _count = count;
        if (!_itemToPickUp.IsStackable)
            _count = 1;
        else if (_count > _itemToPickUp.MaxStack)
            _count = _itemToPickUp.MaxStack;

        PickableManager.Instance.AddToList(this);
    }

    public void Interract(CharacterBase user) {
        PlayerDrivenCharacter player = (PlayerDrivenCharacter)user;

        AddItemCallback callback =  player.InventoryHandler.AddItem(_itemToPickUp, _count);
        switch (callback.Result) {
            case AddItemCallback.ResultType.Success:
                PickableManager.Instance.RemoveFromList(this);
                Destroy(this.gameObject);
                break;
            case AddItemCallback.ResultType.Partially:
                _count = callback.NotAddedCount;
                break;
            case AddItemCallback.ResultType.Failed:
                break;
        }
    }

    private void OnValidate() {
        if (_count <= 0)
            _count = 1;
    }
}
